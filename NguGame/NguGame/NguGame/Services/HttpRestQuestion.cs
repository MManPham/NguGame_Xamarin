using Newtonsoft.Json;
using NguGame.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NguGame.Services
{
    public class HttpRestQuestion
    {
        public async Task<List<T>> GetQuestions<T>(string URL)
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

        public async Task PostQuestion(string URL, Question question_post)
        {
            if (NetworkCheck.IsInternet())
            {
                try
                {
                    HttpClient client = new HttpClient();
                    var json = JsonConvert.SerializeObject(question_post);

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
    }
}
