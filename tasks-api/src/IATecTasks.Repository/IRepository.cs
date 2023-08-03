using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Repository
{
    public interface IRepository<T>
    {
        T[] GetAll(int id);
        T[] GetAllByUserId(int id, string userId);
        void Insert(T entity);
        void Update(string id, T entity);
        void Delete(string id);
    }
}
