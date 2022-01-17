using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WogiaFoods.Models;
using WogiaFoods.Views;
using Xamarin.Forms;

namespace WogiaFoods.ViewModels
{
    public class ProductDetailsViewModel: BaseViewModel
    {
        private FoodItem _SelectedFoodItem;
        public FoodItem SelectedFoodItem
        {
            get { return _SelectedFoodItem; }
            set { _SelectedFoodItem = value; OnPropertyChanged(); }
        }

        private int _TotalQuantity;
        public int TotalQuantity
        {
            get { return _TotalQuantity; }
            set
            {
                this._TotalQuantity = value;
                if (this._TotalQuantity < 0) { this._TotalQuantity = 0; }
                if (this._TotalQuantity == 10) { this._TotalQuantity -= 1; }
                OnPropertyChanged();
            }
        }

        public Command DecrementOrderCommand { get; set; }
        public Command IncrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomeCommand { get; set; }
        private async Task GoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ViewCart());
        }
        private void DecrementOrder()
        {
            TotalQuantity--;
        }

        private void IncrementOrder()
        {
            TotalQuantity++;
        }
        private void AddToCart()
        {
            var Conn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                CartItem cartItem = new CartItem()
                {
                    ProductId = SelectedFoodItem.ProductID,
                    ProductName = SelectedFoodItem.Name,
                    Price = SelectedFoodItem.Price,
                    Quantity = TotalQuantity
                };
                var item = Conn.Table<CartItem>().ToList()
                               .FirstOrDefault(f => f.ProductId == SelectedFoodItem.ProductID);
                if (item == null) 
                {
                    Conn.Insert(cartItem);
                    var items = Conn.Table<CartItem>().ToList();
                } 
                else
                {
                    item.Quantity += TotalQuantity;
                }
                Conn.Commit();
                Conn.Close();
                Application.Current.MainPage.DisplayAlert("Success", "Item Successfully added to Cart", "Ok");

            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                Conn.Close();
            }
        }
        public ProductDetailsViewModel(FoodItem foodItem)
        {
            SelectedFoodItem = foodItem;
            TotalQuantity = 0;
            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(async () => await ViewCartAsync());
            HomeCommand = new Command(async () => await GoHomeAsync());
        }
    }
}
