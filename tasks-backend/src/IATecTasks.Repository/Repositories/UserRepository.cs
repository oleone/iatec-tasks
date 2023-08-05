using IATecTasks.Domain.Identity;
using IATecTasks.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Repository.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(IATecTasksContext context) : base(context) { }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == username.ToLower());
        }
    }
}
