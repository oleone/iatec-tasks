using AutoMapper;
using IATecTasks.Application.Dtos.User;
using IATecTasks.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases.User
{
    public class CheckUserPasswordUseCase
    {
        private readonly UserManager<Domain.Identity.User> _userManager;
        private readonly SignInManager<Domain.Identity.User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CheckUserPasswordUseCase(UserManager<Domain.Identity.User> userManager,
                                    SignInManager<Domain.Identity.User> signInManager,
                                    IMapper mapper,
                                    IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<SignInResult> Execute(UserUpdateDto userUpdateDto, string password)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(user => user.UserName == userUpdateDto.Username.ToLower());

                return await _signInManager.CheckPasswordSignInAsync(user, password, false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar usuário e senha. Erro: {ex.Message}");
            }
        }
    }
}
