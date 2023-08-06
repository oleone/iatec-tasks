using IATecTasks.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.Interfaces.Account
{
    public interface IUpdateAccountUseCase
    {
        Task<UserUpdateDto> Execute(UserUpdateDto userUpdate);
    }
}
