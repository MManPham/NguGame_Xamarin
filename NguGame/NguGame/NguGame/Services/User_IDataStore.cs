using NguGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NguGame.Services
{
    public interface User_IdataStore<T>
    {
        Task<bool> AddUser(T item);
        Task<T> GetUserAsync(string nameUser);
        Task<User> CheckDeviceAsync(string nameDevice);
        Task<User> UpdateUser(T item);
        Task<List<T>> GetAllUserAsync(bool forceRefresh = false);
    }
}
