using AutoMapper;
using Messenger.Domain;
using Messenger.Domain.Models;
using Messenger.WebApi.Dto.Account;
using Messenger.WebApi.Dto.Friends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Net;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Messenger.WebApi.Controllers
{
    [Authorize]
    public class FriendsController : MessengerController
    {
        public FriendsController(MessengerContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<FriendDto>), (int)HttpStatusCode.OK)]
        public IActionResult GetAll(string? keyword)
        {
            var userId = CurrentUserId;
            IQueryable<Friend> query = Context.Friends
                .Include(f => f.UserFriend)
                .Where(f => f.UserId == userId);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(f => f.UserFriend.Nickname.ToLower().Contains(keyword.ToLower()) || f.UserFriend.Name.ToLower().Contains(keyword.ToLower()));
            }
            
            var a = query.Select(f => f.UserFriend).ToList();
            return Ok(Mapper.Map<IEnumerable<FriendDto>>(a));
        }

        [HttpGet("[action]")]
        public IActionResult Add(int friendId)
        {
            var friend = Context.Users.FirstOrDefault(u => u.Id == friendId);
            if (friend == null)
            {
                return BadRequest("Такого пользователя не удалось найти");
            } 
            // TODO использовать токен для определения пользователя который сделал вызов
            Context.Friends.Add(new Friend(1, friend.Id));
            Context.SaveChanges();
            return Ok($"Пользователь {friend.Nickname} добавлен в список ваших друзей");
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int friendId)
        {
            var entity = Context.Friends.FirstOrDefault(f => f.UserId == 1 && f.UserFriendId == friendId);
            if (entity == null)
            {
                BadRequest("Пользователя с таким Id не найдено");
            }
            Context.Friends.Remove(entity);
            Context.SaveChanges();
            return Ok();
        }
    }
}
