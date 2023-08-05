using IATecTasks.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Repository.Repositories
{
    public interface ITaskRepository : IRepository
    {
        Task<IEnumerable<ETask>> GetAllTasksByUserIdAsync(string userId);
    }
}
