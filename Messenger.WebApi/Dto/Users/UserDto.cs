using AutoMapper;
using Messenger.Domain.Models;

namespace Messenger.WebApi.Dto.Users
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class UserDto : EntityDto
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
        public string Avatar { get; set; }
    }
}
