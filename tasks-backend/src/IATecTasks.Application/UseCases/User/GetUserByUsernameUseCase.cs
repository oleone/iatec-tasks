using AutoMapper;
using IATecTasks.Application.Dtos.User;
using IATecTasks.Application.Interfaces;
using IATecTasks.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases.User
{
    public class GetUserByUserNameUseCase : IGetUserByUserNameUseCase
    {
        private readonly UserManager<Domain.Identity.User> _userManager;
        private readonly SignInManager<Domain.Identity.User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByUserNameUseCase(UserManager<Domain.Identity.User> userManager,
                                    SignInManager<Domain.Identity.User> signInManager,
                                    IMapper mapper,
                                    IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserUpdateDto> Execute(string userName)
        {
            try
            {
                var user = await _userRepository.GetUserByUserNameAsync(userName);
                
                if (user == null) return null;

                var userUpdateDto = _mapper.Map<UserUpdateDto>(user);

                return userUpdateDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");
            }
        }
    }
}
