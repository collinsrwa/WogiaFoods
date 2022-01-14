using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WogiaFoods.Models;
using Xamarin.Forms;

namespace WogiaFoods.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }
        FirebaseClient _client;
        string fireBaseUrl = AppSettingsManager.Settings["ConnectionStrings:FireBaseDB"];
        public AddCategoryData()
        {
            _client = new FirebaseClient(fireBaseUrl);
            Categories = new List<Category>()
                {
                    new Category {CategoryID=1, CategoryName= "Pizza", CategoryPoster="Pizza.jpg", ImageUrl="Pizza.jpg" },
                    new Category {CategoryID=2, CategoryName= "Chicken", CategoryPoster="Chicken.jpg", ImageUrl="Chicken.jpg" },
                    new Category {CategoryID=3, CategoryName= "Burger", CategoryPoster="Burger.jpg", ImageUrl="Burger.jpg" },
                    new Category {CategoryID=4, CategoryName= "Meat", CategoryPoster="Roasted.jpg", ImageUrl="Roasted.jpg" },
                    new Category {CategoryID=5, CategoryName= "Fries", CategoryPoster="Fries.jpg", ImageUrl="Fries.jpg" },
                    new Category {CategoryID=6, CategoryName= "Hot Beaverages", CategoryPoster="Beaverages.jpg", ImageUrl="Beaverages.jpg" },
                    new Category {CategoryID=7, CategoryName= "Cold Beaverages", CategoryPoster="ColdBeaverages.jpg", ImageUrl="ColdBeaverages.jpg" }
                };      
        }
        public async Task AddCategoryAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await _client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID=category.CategoryID,
                        CategoryName=category.CategoryName,
                        CategoryPoster= category.CategoryPoster,
                        ImageUrl= category.ImageUrl
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}
