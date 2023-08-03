using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Application.UseCases
{
    public interface IUseCase<T>
    {
        void Execute(T dto);
    }
}
