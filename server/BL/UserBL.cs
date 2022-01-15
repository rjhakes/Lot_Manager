using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL;
using Models;
namespace BL
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepo _repo;
        public UserBL(IUserRepo repo)
        {
            _repo = repo;

        }
        public async Task<User> AddUserAsync(User newUser)
        {
            return await _repo.AddUserAsync(newUser);
        }

        public async Task<User> DeleteUserAsync(User user2BDeleted)
        {
            return await _repo.DeleteUserAsync(user2BDeleted);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _repo.GetUserByIdAsync(id);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _repo.GetUserByEmailAsync(email);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _repo.GetUsersAsync();
        }

        public async Task<User> UpdateUserAsync(User user2BUpdated)
        {
            return await _repo.UpdateUserAsync(user2BUpdated);
        }
    }
}