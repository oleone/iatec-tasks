using IATecTasks.Domain.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Repository
{
    public class IATecTasksContext : DbContext
    {
        public IATecTasksContext(DbContextOptions<IATecTasksContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }
}
