using IATecTasks.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.Interfaces.Account
{
    public interface ICreateTokenUseCase
    {
        Task<string> Execute(UserUpdateDto userUpdateDto);
    }
}
