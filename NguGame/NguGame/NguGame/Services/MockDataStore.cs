using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NguGame.DataAccess;
using NguGame.Models;

namespace NguGame.Services
{
    public class MockDataStore : IDataStore<Question>
    {
        List<Question> QuestionList;

        public MockDataStore()
        {
            DataConnect _dataConnect = new  DataConnect();


             QuestionList = new List<Question>();
            var mockQuestions = _dataConnect.ListGoogleSheetValue();

            foreach (var item in mockQuestions)
            {
                Question newQuestion = new Question(item);
                QuestionList.Add(newQuestion);
            }
        }


        public Task<bool> AddQuestionAsync(Question item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteQuestionAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetAllQuestionsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
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