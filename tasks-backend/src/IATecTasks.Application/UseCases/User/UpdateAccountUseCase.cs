using IATecTasks.Application.Dtos.User;
using IATecTasks.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IATecTasks.Domain.Identity;
using AutoMapper;
using Newtonsoft.Json.Linq;

namespace IATecTasks.Application.UseCases.User
{
    public class UpdateAccountUseCase
    {
        private readonly UserManager<Domain.Identity.User> _userManager;
        private readonly SignInManager<Domain.Identity.User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateAccountUseCase(UserManager<Domain.Identity.User> userManager,
                                    SignInManager<Domain.Identity.User> signInManager,
                                    IMapper mapper,
                                    IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserUpdateDto> Execute(UserUpdateDto userUpdate)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userUpdate.UserName);

                if (user == null) return null;

                _mapper.Map(userUpdate, user);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, userUpdate.Password);

                _userRepository.Update<Domain.Identity.User>(user);

                if (await _userRepository.SaveChangesAsync())
                {
                    var userToReturn = await _userRepository.GetUserByUserNameAsync(userUpdate.UserName);
                    return _mapper.Map<UserUpdateDto>(userToReturn);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar usuário. Erro: {ex.Message}");
            }
        }
    }
}
