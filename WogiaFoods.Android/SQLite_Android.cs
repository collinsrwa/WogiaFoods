using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WogiaFoods.Models;
using Xamarin.Forms;

[assembly:Dependency(typeof(WogiaFoods.Droid.SQLite_Android))]
namespace WogiaFoods.Droid
{
    class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqLiteFileName = "WogiaFoods.db";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqLiteFileName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}