using IATecTasks.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.Interfaces
{
    public interface IListTaskUseCase
    {
        Task<List<ListTaskDto>> Execute(string id);
    }
}
