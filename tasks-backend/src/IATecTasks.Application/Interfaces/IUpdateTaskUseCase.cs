using IATecTasks.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.Interfaces
{
    public interface IUpdateTaskUseCase
    {
        Task<bool> Execute(UpdateTaskDto dto);
    }
}
