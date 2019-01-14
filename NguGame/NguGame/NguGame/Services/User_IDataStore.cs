using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NguGame.Services
{
    public interface User_IdataStore<T>
    {
        Task<bool> AddUser(T item);
        Task<T> GetUserAsync(string id);
        Task<List<T>> GetAllUserAsync(bool forceRefresh = false);
    }
}
