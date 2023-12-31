﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IATecTasks.Domain;
using IATecTasks.Repository.Interfaces;
using IATecTasks.Domain.Identity;

namespace IATecTasks.Repository.Repositories
{
    public class TaskRepository : Repository, ITaskRepository
    {
        public TaskRepository(IATecTasksContext context) : base(context) { }

        public async Task<IEnumerable<ETask>> GetAllTasksByUserIdAsync(string userId)
        {
            IQueryable<ETask> query = _context.Tasks.Where(t => t.UserId == userId);

            return await query.ToListAsync();
        }

        public async Task<ETask> GetETaskById(string id)
        {
            return await _context.Tasks.FindAsync(id);
        }
    }
}
