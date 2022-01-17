using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WogiaFoods.Helpers;

namespace WogiaFoods.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
         async void BtnCategories_Clicked(System.Object sender, System.EventArgs e)
        {
            var addCategoryData = new AddCategoryData();
            await addCategoryData.AddCategoryAsync();
        }
        async void BtnProducts_Clicked(System.Object sender, System.EventArgs e)
        {
            var addFoodItemData = new AddFoodItemData();
            await addFoodItemData.AddFoodItemAsync();
        }
         void BtnCart_Clicked(System.Object sender, System.EventArgs e)
        {
            var createTable = new CreateCartTable();
            if (createTable.CreateTable())
                DisplayAlert("Success", "Cart Created Table", "Ok");
            else
                DisplayAlert("Error", "Error while creating Table", "Ok");
        }
    }
}