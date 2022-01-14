using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WogiaFoods.Models;

namespace WogiaFoods.Services
{
    class FoodItemService
    {
        FirebaseClient _client;
        string fireBaseUrl = AppSettingsManager.Settings["ConnectionStrings:FireBaseDB"];
        public FoodItemService()
        {
            _client = new FirebaseClient(fireBaseUrl);
        }
        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var foodItems = (await _client.Child("FoodItems")
                .OnceAsync<FoodItem>())
                .Select(c => new FoodItem
                {
                    CategoryID = c.Object.CategoryID,
                    ProductID = c.Object.ProductID,
                    Name = c.Object.Name,
                    ImageUrl = c.Object.ImageUrl,
                    Price= c.Object.Price,
                    Description= c.Object.Description,
                    Rating = c.Object.Rating,
                    RatingDetail = c.Object.RatingDetail,
                    HomeSelected= c.Object.HomeSelected
                }).ToList();
            return foodItems;
        }
        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(c => c.CategoryID == categoryID).ToList();
            foreach (var item in items)
            {
                foodItemsByCategory.Add(item);
            }
            return foodItemsByCategory;
        }
        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3).ToList();
            foreach (var item in items)
            {
                latestFoodItems.Add(item);
            }
            return latestFoodItems;
        }
    }
}
