using IATecTasks.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.Interfaces.ETask
{
    public interface IDeleteTaskUseCase
    {
        Task<bool> Execute(string id);
    }
}
