using Newtonsoft.Json;
using NguGame.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NguGame.Services
{
    public class UserHttpRest
    {
        public async Task<T> GetUserbyName<T>(string URL)
        {
            if (NetworkCheck.IsInternet())
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.MaxResponseContentBufferSize = 256000;
                    string res = await client.GetStringAsync(URL);
                    if (res != "")
                    {
                        List<T> uls = JsonConvert.DeserializeObject<List<T>>(res);
                        return uls[0];
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return default(T);
        }




        public async Task<T> CheckDevice<T>(string URL)
        {
            if (NetworkCheck.IsInternet())
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.MaxResponseContentBufferSize = 256000;
                    string res = await client.GetStringAsync(URL);
                    if (res != "")
                    {
                        List<T> uls = JsonConvert.DeserializeObject<List<T>>(res);
                        return uls[0];
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return default(T);
        }


        public async Task<List<T>> GetALLUser<T>(string URL)
        {
            if (NetworkCheck.IsInternet())
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.MaxResponseContentBufferSize = 256000;
                    HttpResponseMessage res = await client.GetAsync(URL);

                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var jsonString = await res.Content.ReadAsStringAsync();
                        List<T> qls = new List<T>();
                        if (jsonString != "")
                        {
                            //Converting JSON Array Objects into generic list  
                            qls = JsonConvert.DeserializeObject<List<T>>(jsonString);
                            return qls;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return default(List<T>);
        }

        public async Task PostUse(string URL, User user_post)
        {
            if (NetworkCheck.IsInternet())
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.MaxResponseContentBufferSize = 256000;

                    var json = JsonConvert.SerializeObject(user_post);

                    HttpContent content = new StringContent(json);

                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage res = await client.PostAsync(URL, content);

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<T> UpdateUser<T>(string URL, User user_put)
        {
            if (NetworkCheck.IsInternet())
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.MaxResponseContentBufferSize = 256000;

                    var json = JsonConvert.SerializeObject(user_put);

                    HttpContent content = new StringContent(json);

                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage res = await client.PutAsync(URL, content);
                 
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return default(T);
        }
    }
}
