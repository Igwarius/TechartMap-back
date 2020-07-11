using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechartMap_back.DAL.Models;
using TechartMap_back.DAL.Repository.Interfaces;

namespace TechartMap_back.DAL.Repository.Classes
{
    public class UserRepository: IUserRepository
    {
        private readonly Context.Context _context;
        public UserRepository(Context.Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.FromResult(_context.Users);
        }
        public async Task<User> GetCurrentUser(string login)
        {
            var user = await _context.Users.FindAsync(login);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public async Task AddUser(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == user.Login);

            if (existingUser == null)
            {
                await _context.Users.AddAsync(user);

            }

            await _context.SaveChangesAsync();
        }
        public async Task<User> CheckUser(User user)
        {
            
            
            var foundUser =
                await _context.Users.FirstOrDefaultAsync(x => x.Login == user.Login && x.Password == user.Password);
            if (foundUser != null)
            {
                return foundUser;

            }
            return null;
        }


    }
}
