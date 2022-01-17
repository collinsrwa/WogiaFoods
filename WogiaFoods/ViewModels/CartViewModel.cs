using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WogiaFoods.Models;
using WogiaFoods.Services;
using WogiaFoods.Views;
using Xamarin.Forms;

namespace WogiaFoods.ViewModels
{
    public class CartViewModel: BaseViewModel
    {
        public ObservableCollection<UserCartItem> CartItems { get; set; }
        private decimal _TotalCost;
        public decimal TotalCost
        {
            get { return _TotalCost; }
            set { _TotalCost = value; OnPropertyChanged(); }
        }
        public Command PlaceOrdersCommand { get; set; }
        public CartViewModel()
        {
            CartItems = new ObservableCollection<UserCartItem>();
            LoadItems();
            PlaceOrdersCommand = new Command(async () => await PlaceOrdersAsync());
        }

        private async Task PlaceOrdersAsync()
        {
            var id = await new OrderService().PlaceOrderAsync() as string;
            RemoveItemsFromCart();
            await Application.Current.MainPage.Navigation.PushModalAsync(new OrdersView(id));
        }

        private void RemoveItemsFromCart()
        {
            CartItemService cartItemService = new CartItemService();
            cartItemService.RemoveItemsFromCart();
        }

        private void LoadItems()
        {
            var conn = DependencyService.Get<ISQLite>().GetConnection();
            var items = conn.Table<CartItem>().ToList();
            CartItems.Clear();
            foreach (var item in items)
            {
                CartItems.Add(new UserCartItem()
                {
                   CartItemId= item.CartItemId,
                   ProductId = item.ProductId,
                   ProductName= item.ProductName,
                   Quantity= item.Quantity,
                   Price = item.Price,
                   Cost= item.Price * item.Quantity
                });
                TotalCost += (item.Price * item.Quantity);
            }
        }
    }
}
