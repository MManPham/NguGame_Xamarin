using NguGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NguGame.Services
{
    public class User_MKStore : User_IdataStore<User>
    {
        public UserHttpRest client { get; set; }
        public string URL { get; set; }

        public User_MKStore()
        {
            client = new UserHttpRest();
            URL = "http://192.168.100.25:3000/user";
        }
        public async Task<bool> AddUser(User item)
        {
            try
            {
                await client.PostUse(URL, item);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<User> GetUserAsync(string user_name)
        {
            this.URL = this.URL + "/" + user_name;
            return await client.GetUser<User>(URL);

        }
        public async Task<List<User>> GetAllUserAsync(bool forceRefresh = false)
        {
            List<User> User = await client.GetALLUser<User>(this.URL);
            return User;

        }


    }
}
