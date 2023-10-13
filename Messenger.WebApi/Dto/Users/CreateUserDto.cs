using AutoMapper;
using Messenger.Domain.Models;

namespace Messenger.WebApi.Dto.Users
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class CreateUserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
    }
}
