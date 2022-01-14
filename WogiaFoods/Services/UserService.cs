using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WogiaFoods.Models;
using Firebase.Database.Query;

namespace WogiaFoods.Services
{
    class UserService
    {
        FirebaseClient client;
        string fireBaseUrl = AppSettingsManager.Settings["ConnectionStrings:FireBaseDB"];
        public UserService()
        {
            client = new FirebaseClient(fireBaseUrl);
        }

        public async Task<bool> UserExists(string userName)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Username == userName).FirstOrDefault();
            return (user != null);
        }
        public async Task<bool> RegisterUser(string userName, string passWord)
        {
            if(await UserExists(userName) == false)
            {
                await client.Child("Users").PostAsync(new User()
                {
                    Username=userName,
                    Password=passWord
                });
                return true;
            }
            else { return false; }
        }
        public async Task<bool> LoginUser(string userName, string passWord)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Username == userName)
                      .Where(u => u.Object.Password == passWord).FirstOrDefault();
            return (user != null);
        }
    }
}
