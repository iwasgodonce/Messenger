using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Domain.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public bool IsMale { get; set; }    
        public int Age { get; set; }
        public string? Avatar { get; set; }
        public ICollection<Friend> Friends { get; set; }
        public DateTime LastTimeOnline { get; set; }
        public bool IsOnline { get; set; }

        public string Login { get; set; }    
        public string Password { get; set; }
    }
}
