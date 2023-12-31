﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Repository.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entityArray) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
