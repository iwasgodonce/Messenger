using AutoMapper;
using Messenger.Domain;
using Messenger.Domain.Models;
using Messenger.WebApi.Dto.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace Messenger.WebApi.Controllers
{
    [Authorize]
    public class UsersController : MessengerController
    {
        public UsersController(MessengerContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet("[action]")]
        public IActionResult GetAll(string keyword)
        {
            var users = Context.Users.Where(u => u.Nickname.ToLower() == keyword.ToLower()).ToList();
            return Ok(Mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("[action]")]
        [ProducesDefaultResponseType(typeof(UserDto))]
        public IActionResult Get(int id)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return BadRequest("Пользователя с таким Id не найдено");
            }
            return Ok(Mapper.Map<UserDto>(user));
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {
            var user = Context.Users.FirstOrDefault(a => a.Id == id);
            if (user == null)
            {
                return BadRequest("Пользователя с таким Id не найдено");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult Update(UserDto input)
        {
            var user = Context.Users.FirstOrDefault(a => a.Id == input.Id);
            if (user == null)
            {
                return BadRequest("Пользователя с таким Id не найдено");
            }

            Mapper.Map(input, user);
            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok();
        }
    }
}
