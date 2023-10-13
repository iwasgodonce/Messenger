using Messenger.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Domain
{
    public class MessengerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Message> Messages { get; set; }

        public MessengerContext(DbContextOptions options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasKey(x => new {x.UserId, x.UserFriendId});
            modelBuilder.Entity<Friend>().HasOne(x => x.User).WithMany(x => x.Friends).HasForeignKey(x => x.UserId);
            //modelBuilder.Entity<Friend>().HasOne(x => x.UserFriend).WithMany(x => x.Friends).HasForeignKey(x => x.UserFriendId);
        }
    }
}
