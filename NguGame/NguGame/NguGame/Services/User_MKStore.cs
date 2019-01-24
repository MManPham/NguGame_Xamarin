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
            URL = "http://192.168.100.41:3000";
        }
        public async Task<bool> AddUser(User item)
        {
            try
            {
                await client.PostUse(URL + "/user/", item);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<User> GetUserAsync(string user_name)
        {
            this.URL = this.URL + "/user/" + user_name;
            return await client.GetUserbyName<User>(URL);

        }
        public async Task<List<User>> GetAllUserAsync(bool forceRefresh = false)
        {
            List<User> User = await client.GetALLUser<User>(this.URL + "/user");
            return User;

        }

        public async Task<User> CheckDeviceAsync(string nameDevice)
        {
            this.URL = this.URL + "/userDevice/" + nameDevice;

            try
            {
               return await client.CheckDevice<User>(URL);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<User> UpdateUser(User item)
        {
            this.URL = this.URL + "/userDevice/" + item.nameDivice;

            try
            {
                return await client.UpdateUser<User>(URL,item);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
