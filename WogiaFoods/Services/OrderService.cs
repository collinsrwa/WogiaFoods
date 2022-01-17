using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WogiaFoods.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WogiaFoods.Services
{
    public class OrderService
    {
        FirebaseClient _client;
        string fireBaseUrl = AppSettingsManager.Settings["ConnectionStrings:FireBaseDB"];
        public OrderService()
        {
            _client = new FirebaseClient(fireBaseUrl);
        }
        public async Task <string> PlaceOrderAsync()
        {
            var conn = DependencyService.Get<ISQLite>().GetConnection();
            var items = conn.Table<CartItem>().ToList();
            var orderId = Guid.NewGuid().ToString();
            var uname = Preferences.Get("UserName", "Guest");
            decimal TotalCost = 0;
            foreach (var item in items)
            {
                OrderDetails od = new OrderDetails()
                {
                   OrderDetailId = Guid.NewGuid().ToString(),
                   OrderId= orderId,
                   Price= item.Price,
                   ProductName= item.ProductName,
                   ProductID = item.ProductId,
                   Quantity= item.Quantity

                };
                TotalCost += (item.Price * item.Quantity);
                await _client.Child("OrderDetails").PostAsync(od);
            }
            await _client.Child("Orders").PostAsync(
                new Order()
                {
                    OrderId = orderId,
                    UserName = uname,
                    TotalCost = TotalCost

                });
            return orderId;
        }
    }
}
