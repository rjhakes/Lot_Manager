using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;

namespace BL
{
    public interface IUserBL
    {
        Task<List<User>> GetUsersAsync();
        Task<User> AddUserAsync(User newUser);
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> DeleteUserAsync(User user2BDeleted);
        Task<User> UpdateUserAsync(User user2BUpdated);
    }
}