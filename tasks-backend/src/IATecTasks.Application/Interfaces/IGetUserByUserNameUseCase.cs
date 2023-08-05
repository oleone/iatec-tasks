using IATecTasks.Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.Interfaces
{
    public interface IGetUserByUserNameUseCase
    {
        Task<UserUpdateDto> Execute(string userName);
    }
}
