using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using IATecTasks.Application.Interfaces;
using IATecTasks.Application.Dtos.User;
using IATecTasks.Application.UseCases.User;
using IATecTasks.API.Extensions;
using IATecTasks.Application.Interfaces.Account;

namespace IATecTasks.API.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IGetUserByUserNameUseCase _getUserByUserNameUseCase;
        private readonly ICreateAccountUseCase _createAccountUseCase;
        private readonly ICheckUserPasswordUseCase _checkUserPasswordUseCase;
        private readonly IUpdateAccountUseCase _updateAccountUseCase;
        private readonly ICreateTokenUseCase _createTokenUseCase;
        private readonly ICheckUserExistsUseCase _checkUserExistsUseCase;

        public AccountController(IGetUserByUserNameUseCase getUserByUserNameUseCase,
                                 ICreateTokenUseCase createTokenUseCase,
                                 ICheckUserExistsUseCase checkUserExistsUseCase,
                                 ICreateAccountUseCase createAccountUseCase,
                                 ICheckUserPasswordUseCase checkUserPasswordUseCase,
                                 IUpdateAccountUseCase updateAccountUseCase)
        {
            _getUserByUserNameUseCase = getUserByUserNameUseCase;
            _createTokenUseCase = createTokenUseCase;
            _createAccountUseCase = createAccountUseCase;
            _checkUserPasswordUseCase = checkUserPasswordUseCase;
            _updateAccountUseCase = updateAccountUseCase;
            _checkUserExistsUseCase = checkUserExistsUseCase;
        }

        /// <summary>
        /// Get data for logged user
        /// </summary>
        /// <returns></returns>
        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userName = User.GetUserName();
                var user = await _getUserByUserNameUseCase.Execute(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Usuário. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Sign in user
        /// </summary>
        /// <param name="userLogin">User Login Dto with username and password</param>
        /// <returns></returns>
        [HttpPost("signin")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Signin(UserLoginDto userLogin)
        {
            try
            {
                var user = await _getUserByUserNameUseCase.Execute(userLogin.UserName);
                if (user == null) return Unauthorized("Usuário ou Senha está errado");

                var result = await _checkUserPasswordUseCase.Execute(user, userLogin.Password);
                if (!result.Succeeded) return Unauthorized();

                return Ok(new
                {
                    userName = user.UserName,
                    FirstName = user.FirstName,
                    token = _createTokenUseCase.Execute(user).Result
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar realizar Login. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Sign up new users
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost("signup")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                if (await _checkUserExistsUseCase.Execute(userDto.UserName))
                    return BadRequest("Usuário já existe");

                var user = await _createAccountUseCase.Execute(userDto);
                if (user != null)
                    return Ok(new
                    {
                        userName = user.UserName,
                        FirstName = user.FirstName,
                        token = _createTokenUseCase.Execute(user).Result
                    });

                return BadRequest("Usuário não criado, tente novamente mais tarde!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Registrar Usuário. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Update logged user
        /// </summary>
        /// <param name="userUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            try
            {
                if (userUpdateDto.UserName != User.GetUserName())
                    return Unauthorized("Usuário Inválido");

                var user = await _getUserByUserNameUseCase.Execute(User.GetUserName());
                if (user == null) return Unauthorized("Usuário Inválido");

                var userReturn = await _updateAccountUseCase.Execute(userUpdateDto);
                if (userReturn == null) return NoContent();

                return Ok(new
                {
                    userName = userReturn.UserName,
                    FirstName = userReturn.FirstName,
                    token = _createTokenUseCase.Execute(userReturn).Result
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Atualizar Usuário. Erro: {ex.Message}");
            }
        }
    }
}
