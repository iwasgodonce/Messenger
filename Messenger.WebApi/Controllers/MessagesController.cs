using AutoMapper;
using Messenger.Domain;
using Messenger.Domain.Models;
using Messenger.WebApi.Dto.Messages;
using Messenger.WebApi.Dto.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.WebApi.Controllers
{
    public class MessagesController : MessengerController
    {
        public MessagesController(MessengerContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var messages = Context.Messages.ToList();
            return Ok(Mapper.Map<IEnumerable<MessageDto>>(messages));
        }

        [HttpGet("[action]")]
        public IActionResult Get(int id)
        {
            var message = Context.Messages.FirstOrDefault(x => x.Id == id);
            if (message == null)
            {
                return BadRequest("Сообщения с таким Id не найдено");
            }
            return Ok(Mapper.Map<MessageDto>(message));
        }

        [HttpPost("[action]")]
        public IActionResult Create(CreateMessageDto input)
        {
            var message = Mapper.Map<Message>(input);
            Context.Messages.Add(message);
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {
            var message = Context.Messages.FirstOrDefault(a => a.Id == id);
            if (message == null)
            {
                return BadRequest("Сообщения с таким Id не найдено");
            }
            Context.Messages.Remove(message);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult Update(MessageDto input)
        {
            var message = Context.Messages.FirstOrDefault(a => a.Id == input.Id);
            if (message == null)
            {
                return BadRequest("Сообщения с таким Id не найдено");
            }

            Mapper.Map(input, message);
            Context.Messages.Update(message);
            Context.SaveChanges();
            return Ok();
        }
    }
}
