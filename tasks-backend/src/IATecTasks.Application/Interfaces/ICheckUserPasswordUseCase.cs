using IATecTasks.Application.Dtos.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.Interfaces
{
    public interface ICheckUserPasswordUseCase
    {
        Task<SignInResult> Execute(UserUpdateDto userUpdateDto, string password);
    }
}
