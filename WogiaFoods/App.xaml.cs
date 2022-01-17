using System;
using WogiaFoods.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WogiaFoods
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //Setting main page as login
            //MainPage = new LoginView();
            //MainPage = new NavigationPage(new SettingsPage());
            var uname = Preferences.Get("UserName", string.Empty);
            if (String.IsNullOrEmpty(uname))
                MainPage = new LoginView();
            else
                MainPage = new ProductsView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
