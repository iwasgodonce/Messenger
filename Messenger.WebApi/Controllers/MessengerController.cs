using AutoMapper;
using Messenger.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Messenger.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MessengerController : ControllerBase
    {
        protected MessengerContext Context { get; set; }

        protected IMapper Mapper { get; set; }

        protected int CurrentUserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        protected MessengerController(MessengerContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}
