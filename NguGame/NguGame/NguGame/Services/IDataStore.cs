using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NguGame.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddQuestionAsync(T item);
        Task<bool> DeleteQuestionAsync(string id);
        Task<T> GetQuestionAsync(string id);
        Task<IEnumerable<T>> GetAllQuestionsAsync(bool forceRefresh = false);
    }
}
