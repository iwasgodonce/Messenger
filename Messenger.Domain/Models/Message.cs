using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Domain.Models
{
    public class Message : Entity
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


        public int UserSenderId { get; set; }
        [ForeignKey("UserSenderId")]
        public User UserSender { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
