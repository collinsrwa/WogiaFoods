using System;
using System.Collections.Generic;
using System.Text;
using WogiaFoods.Models;
using Xamarin.Forms;

namespace WogiaFoods.Helpers
{
    public class CreateCartTable
    {
        public bool CreateTable()
        {
            try
            {
                var conn = DependencyService.Get<ISQLite>().GetConnection();
                conn.CreateTable<CartItem>();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }    
        }
    }
}
