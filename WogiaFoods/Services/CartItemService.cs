using System;
using System.Collections.Generic;
using System.Text;
using WogiaFoods.Models;
using Xamarin.Forms;

namespace WogiaFoods.Services
{
    class CartItemService
    {
        public int GetUserCartCount()
        {
            var conn = DependencyService.Get<ISQLite>().GetConnection();
            var count = conn.Table<CartItem>().Count();
            conn.Close();
            return count;
        }
        public void RemoveItemsFromCart()
        {
            var conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.DeleteAll<CartItem>();
            conn.Commit();
            conn.Close();

        }
    }
}
