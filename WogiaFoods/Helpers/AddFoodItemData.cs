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
    public class AddFoodItemData
    {
        public List<FoodItem> FoodItems { get; set; }
        FirebaseClient _client;
        string fireBaseUrl = AppSettingsManager.Settings["ConnectionStrings:FireBaseDB"];
        public AddFoodItemData()
        {
            _client = new FirebaseClient(fireBaseUrl);
            FoodItems = new List<FoodItem>()
            {
               new FoodItem(){ProductID=1,ImageUrl="HawaianPizza.jpg", Name="Hawaian", Description="Meat Delux", HomeSelected="Heart", Price=1000, Rating="4.5", RatingDetail="(121 Ratings)", CategoryID=1},
               new FoodItem(){ProductID=2,ImageUrl="Drumsticks.jpg", Name="Chicken Drum sticks", Description="Honey Source", HomeSelected="1 piece", Price=300, Rating="3.5", RatingDetail="(126 Ratings)", CategoryID=2},
               new FoodItem(){ProductID=3,ImageUrl="TBone.jpg", Name="T-Bone", Description="T-Bone roast", HomeSelected="Honey dipped", Price=600, Rating="4.5", RatingDetail="(100 Ratings)", CategoryID=4},
               new FoodItem(){ProductID=4,ImageUrl="Fries.jpg", Name="French Fries", Description="Plain French Fries", HomeSelected="Regular", Price=100, Rating="4.0", RatingDetail="(300 Ratings)", CategoryID=5},
               new FoodItem(){ProductID=5,ImageUrl="Friesmasala.jpg", Name="Fries Masala", Description="Fries Masala", HomeSelected="Hot paper", Price=150, Rating="4.5", RatingDetail="(200 Ratings)", CategoryID=5},
               new FoodItem(){ProductID=6,ImageUrl="HotChocolate.jpg", Name="Hot Chocolate", Description="Hot Chocolate", HomeSelected="Single", Price=120, Rating="5", RatingDetail="(250 Ratings)", CategoryID=6},
               new FoodItem(){ProductID=7,ImageUrl="Tea.jpg", Name="Regular Tea", Description="Kenyan Tea", HomeSelected="Single", Price=100, Rating="4.5", RatingDetail="(800 Ratings)", CategoryID=6},
               new FoodItem(){ProductID=8,ImageUrl="soda.jpg", Name="CocaCola", Description="Ice Cold Soda", HomeSelected="Single", Price=100, Rating="4.5", RatingDetail="(800 Ratings)", CategoryID=7},
               new FoodItem(){ProductID=9,ImageUrl="SpicyChikenPizza.jpg", Name="Chiken Pizza", Description="Spicy Chiken Pizza", HomeSelected="Single", Price=100, Rating="4.5", RatingDetail="(800 Ratings)", CategoryID=1},
               new FoodItem(){ProductID=10,ImageUrl="ChickenNuggets.jpg", Name="Chiken Nuggets", Description="Spicy Chiken Nuggets", HomeSelected="Single", Price=100, Rating="4.5", RatingDetail="(800 Ratings)", CategoryID=2},
               new FoodItem(){ProductID=11,ImageUrl="BurgerKing.jpg", Name="Crunch Burger", Description="Plain Burger", HomeSelected="", Price=400, Rating="5", RatingDetail="(156 Ratings)", CategoryID=3},
               new FoodItem(){ProductID=12,ImageUrl="Juice.jpg", Name="Juice", Description="Fresh Juice", HomeSelected="Single", Price=100, Rating="4.5", RatingDetail="(800 Ratings)", CategoryID=7}
            };
        }
        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach (var food in FoodItems)
                {
                    await _client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                       CategoryID= food.CategoryID,
                       ProductID= food.ProductID,
                       Name= food.Name,
                       Price= food.Price,
                       ImageUrl= food.ImageUrl,
                       Description= food.Description,
                       HomeSelected= food.HomeSelected,
                       Rating= food.Rating,
                       RatingDetail= food.RatingDetail

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
