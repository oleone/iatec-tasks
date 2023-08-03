using IATecTasks.Domain.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Repository
{
    public interface ITaskSqlServerRepository : IRepository<Domain.Tasks.Task>
    {
        Task<IEnumerable<Domain.Tasks.Task>> GetAllTasksByUserIdAsync( string userId);
    }
}
