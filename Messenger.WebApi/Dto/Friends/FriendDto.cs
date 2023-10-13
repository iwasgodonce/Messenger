using AutoMapper;
using Messenger.Domain.Models;

namespace Messenger.WebApi.Dto.Friends
{
    [AutoMap(typeof(User), ReverseMap = true)]
    public class FriendDto : EntityDto
    {
        public string Avatar { get; set; }
        public string Nickname { get; set;}
        public bool IsOnline { get; set; }
        public DateTime LastTimeOnline { get; set; }
        public string Name { get; set; }
    }
}
