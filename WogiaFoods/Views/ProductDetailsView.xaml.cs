using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WogiaFoods.Models;
using WogiaFoods.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WogiaFoods.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsView : ContentPage
    {
        ProductDetailsViewModel pvm;
        public ProductDetailsView(FoodItem foodItem)
        {
            InitializeComponent();
            pvm = new ProductDetailsViewModel(foodItem);
            this.BindingContext = pvm;
        }
       
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}