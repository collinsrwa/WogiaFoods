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
    public partial class CategoryView : ContentPage
    {
        CategoryViewModel cvm;
        public CategoryView(Category category)
        {
            InitializeComponent();
            cvm = new CategoryViewModel(category);
            this.BindingContext = cvm;
        }

         async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as FoodItem;
            if (selectedProduct == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailsView(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}