using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.Interfaces
{
    public interface ICheckUserExistsUseCase
    {
        Task<bool> Execute(string userName);
    }
}
