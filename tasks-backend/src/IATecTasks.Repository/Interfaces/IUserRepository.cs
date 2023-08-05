using IATecTasks.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Repository.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetUserByUserNameAsync(string userName);
    }
}
