using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext _context;
        public UserRepo(DataContext context)
        {
            _context = context;

        }
        public async Task<User> AddUserAsync(User newUser)
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> DeleteUserAsync(User user2BDeleted)
        {
            _context.Users.Remove(user2BDeleted);
            await _context.SaveChangesAsync();
            return user2BDeleted;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .Select(user => user)
                .ToListAsync();
        }

        public async Task<User> UpdateUserAsync(User user2BUpdated)
        {
            User oldUser = await _context.Users.Where(b => b.Id == user2BUpdated.Id).FirstOrDefaultAsync();
            _context.Entry(oldUser).CurrentValues.SetValues(user2BUpdated);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return oldUser;
        }
    }
}