using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NguGame.Models;

namespace NguGame.Services
{
    public class MockDataStore : IDataStore<Question>
    {
        public List<Question> QuestionList { get; set; }
        public HttpRestQuestion client { get; set; }
        public string URL { get; set; }

        public  MockDataStore()
        {
            client = new HttpRestQuestion();
            URL = "http://192.168.100.41:3000/question";
        }


        public async Task<bool> AddQuestionAsync(Question item)
        {
            try
            {
                await client.PostQuestion(this.URL, item);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Task<bool> DeleteQuestionAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Question>> GetAllQuestionsAsync(bool forceRefresh = false)
        {
            return await client.GetQuestions<Question>(this.URL);

        }

        public Task<Question> GetQuestionAsync(string id)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> AddQuestionAsync(Question item)
        //{
        //    items.Add(item);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> UpdateQuestionAsync(Question item)
        //{
        //    var oldQuestion = items.Where((Question arg) => arg.Id == item.Id).FirstOrDefault();
        //    items.Remove(oldQuestion);
        //    items.Add(item);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> DeleteQuestionAsync(string id)
        //{
        //    var oldQuestion = items.Where((Question arg) => arg.Id == id).FirstOrDefault();
        //    items.Remove(oldQuestion);

        //    return await Task.FromResult(true);
        //}

        //public async Task<Question> GetQuestionAsync(string id)
        //{
        //    return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        //}

        //public async Task<IEnumerable<Question>> GetQuestionsAsync(bool forceRefresh = false)
        //{
        //    return await Task.FromResult(items);
        //}
    }
}