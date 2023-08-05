﻿using AutoMapper;
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
    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        private readonly UserManager<Domain.Identity.User> _userManager;
        private readonly SignInManager<Domain.Identity.User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateAccountUseCase(UserManager<Domain.Identity.User> userManager,
                                    SignInManager<Domain.Identity.User> signInManager,
                                    IMapper mapper,
                                    IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Execute(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<Domain.Identity.User>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserDto>(user);
                    return userToReturn;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar password. Erro: {ex.Message}");
            }
        }
    }
}
