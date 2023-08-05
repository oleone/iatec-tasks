using IATecTasks.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases
{
    public interface IUseCase<T>
    {
        void Execute(T dto);
        Task<List<ListTaskDto>> Execute(string id);
    }
}
