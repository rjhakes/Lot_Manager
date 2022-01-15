using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public interface IUserRepo
    {
        Task<User> AddUserAsync(User newUser);
        Task<User> DeleteUserAsync(User user2BDeleted);
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetUsersAsync();
        Task<User> UpdateUserAsync(User user2BUpdated);
    }
}