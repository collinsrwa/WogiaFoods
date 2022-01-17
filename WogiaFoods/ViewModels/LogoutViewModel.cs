using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WogiaFoods.Services;
using WogiaFoods.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WogiaFoods.ViewModels
{
    public class LogoutViewModel: BaseViewModel
    {
        CartItemService service = new CartItemService();
        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            get { return _UserCartItemsCount; }
            set { _UserCartItemsCount = value; OnPropertyChanged(); }
        }
        private bool _IsCartExists;
        public bool IsCartExists
        {
            get { return _IsCartExists; }
            set { _IsCartExists = value;  OnPropertyChanged(); }
        }
        public Command LogoutCommand { get; set; }
        public Command GoToCartCommand { get; set; }

        public LogoutViewModel()
        {
            UserCartItemsCount = service.GetUserCartCount();
            IsCartExists = (UserCartItemsCount > 0) ? true : false;
            LogoutCommand = new Command(async () => await LogoutUserAsync());
            GoToCartCommand = new Command(async () => await GoToCartAsync());

        }

        private async Task GoToCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ViewCart());
        }

        private async Task LogoutUserAsync()
        {
          service.RemoveItemsFromCart();
          Preferences.Remove("UserName");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
        }
    }
}
