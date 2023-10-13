using AutoMapper;
using Messenger.Domain;
using Messenger.Domain.Models;
using Messenger.WebApi.Dto.Account;
using Messenger.WebApi.Dto.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Messenger.WebApi.Controllers
{
    public class AccountController : MessengerController
    {
        private readonly IConfiguration _config;
        public AccountController(MessengerContext context, IMapper mapper, IConfiguration config) : base(context, mapper)
        {
            _config = config;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(LoginResponseDto), (int)HttpStatusCode.OK)]
        public IActionResult Login(LoginDto input)
        {
            var user = Context.Users.FirstOrDefault(u => u.Login == input.Login && u.Password == input.Password);
            if (user == null)
            {
                return BadRequest("Неправильно указаны входные параметры");
            }

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            var expires = DateTime.UtcNow.AddHours(2);

            var token = new JwtSecurityToken(
                issuer: _config["AuthOptions:Issuer"],
                audience: _config["AuthOptions:Audience"],
                claims: claims,
                expires: expires ,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["AuthOptions:Key"])),SecurityAlgorithms.HmacSha256));

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);


            return Ok(new LoginResponseDto
            {
                Login = user.Login,
                Token = jwtToken,
                Expires = expires
            });
        }

        [HttpPost("[action]")]
        public IActionResult Create(CreateUserDto input)
        {
            var user = Mapper.Map<User>(input);
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok();
        }
    }
}
