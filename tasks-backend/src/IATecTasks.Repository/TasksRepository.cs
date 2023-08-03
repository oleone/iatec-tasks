using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Repository
{
    public class TasksRepository : ITaskSqlServerRepository
    {
        private readonly IATecTasksContext _context;

        public TasksRepository(IATecTasksContext context)
        {
            _context = context;
        }

        public void Add(Domain.Tasks.Task entity)
        {
            _context.Tasks.Add(entity);
        }

        public void Delete(Domain.Tasks.Task entity)
        {
            _context.Tasks.Remove(entity);
        }

        public void DeleteRange(Domain.Tasks.Task[] entityArray)
        {
            _context.Tasks.RemoveRange(entityArray);
        }

        public async Task<IEnumerable<Domain.Tasks.Task>> GetAllTasksByUserIdAsync(string userId)
        {
            IQueryable<Domain.Tasks.Task> query = _context.Tasks.Where(t => t.UserId == userId && t.IsDeleted == false);

            return await query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update(Domain.Tasks.Task entity)
        {
            _context.Tasks.Update(entity);
        }
    }
}
