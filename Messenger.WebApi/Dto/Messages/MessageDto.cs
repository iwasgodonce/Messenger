using AutoMapper;
using Messenger.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.WebApi.Dto.Messages
{
    [AutoMap(typeof(Message), ReverseMap = true)]
    public class MessageDto : EntityDto
    {
        public int UserId { get; set; }
        
        public int UserSenderId { get; set; }
        
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
