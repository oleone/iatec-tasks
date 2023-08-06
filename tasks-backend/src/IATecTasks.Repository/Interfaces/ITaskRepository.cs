using IATecTasks.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Repository.Interfaces
{
    public interface ITaskRepository: IRepository
    {
        Task<IEnumerable<ETask>> GetAllTasksByUserIdAsync(string userId);
        Task<ETask> GetETaskById(string id);
    }
}
