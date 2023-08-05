using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IATecTasks.Domain;

namespace IATecTasks.Repository.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IATecTasksContext _context;

        public TaskRepository(IATecTasksContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ETask>> GetAllTasksByUserIdAsync(string userId)
        {
            IQueryable<ETask> query = _context.Tasks.Where(t => t.UserId == userId);

            return await query.ToListAsync();
        }
    }
}
