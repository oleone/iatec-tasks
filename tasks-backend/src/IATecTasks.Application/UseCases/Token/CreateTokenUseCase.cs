using AutoMapper;
using IATecTasks.Application.Dtos.User;
using IATecTasks.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases.Token
{
    public class CreateTokenUseCase : ICreateTokenUseCase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<Domain.Identity.User> _userManager;
        private readonly IMapper _mapper;
        private readonly SymmetricSecurityKey _key;

        public CreateTokenUseCase(IConfiguration config,
                                    UserManager<Domain.Identity.User> userManager,
                                    IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
            _mapper = mapper;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public async Task<string> Execute(UserUpdateDto userUpdateDto)
        {
            var user = _mapper.Map<Domain.Identity.User>(userUpdateDto);

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHadler = new JwtSecurityTokenHandler();

            var token = tokenHadler.CreateToken(tokenDescription);

            return tokenHadler.WriteToken(token);
        }
    }
}
