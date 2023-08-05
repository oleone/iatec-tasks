using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IATecTasks.Domain;
using IATecTasks.Repository.Context;

namespace IATecTasks.Repository.Repositories
{
    public class TaskRepository : Repository
    {
        public TaskRepository(IATecTasksContext context) : base(context) { }

        public async Task<IEnumerable<ETask>> GetAllTasksByUserIdAsync(string userId)
        {
            IQueryable<ETask> query = _context.Tasks.Where(t => t.UserId == userId && t.IsDeleted == false);

            return await query.ToListAsync();
        }
    }
}
