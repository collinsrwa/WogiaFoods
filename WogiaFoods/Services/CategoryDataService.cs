using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WogiaFoods.Models;
using System.Linq;
using Firebase.Database.Query;


namespace WogiaFoods.Services
{
    class CategoryDataService
    {
        FirebaseClient _client;
        string fireBaseUrl = AppSettingsManager.Settings["ConnectionStrings:FireBaseDB"];
        public CategoryDataService()
        {
            _client = new FirebaseClient(fireBaseUrl);
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await _client.Child("Categories")
                .OnceAsync<Category>())
                .Select(c => new Category
                {
                    CategoryID = c.Object.CategoryID,
                    CategoryName = c.Object.CategoryName,
                    CategoryPoster = c.Object.CategoryPoster,
                    ImageUrl = c.Object.ImageUrl
                }).ToList();
            return categories;
        }
    }
}
