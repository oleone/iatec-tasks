using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Repository.Contexts
{
    public class IATecTasksContextFactory : IDesignTimeDbContextFactory<IATecTasksContext>
    {
        public IATecTasksContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IATecTasksContext>();
            optionsBuilder.UseSqlite("Data Source=IATecTasks.db");

            return new IATecTasksContext(optionsBuilder.Options);
        }
    }
}
