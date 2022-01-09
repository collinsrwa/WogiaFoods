using System;
using WogiaFoods.Views;
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
            MainPage = new LoginView();
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
