using AutoMapper;
using Messenger.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Messenger.WebApi.Controllers
{
    [Authorize]
    public class PhotosController : MessengerController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PhotosController(MessengerContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment) : base(context, mapper)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK, MediaTypeNames.Image.Jpeg)]
        public IActionResult GetAvatar(int id)
        {
            var user = Context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return BadRequest();
            }

            var pathToAvatar = user.Avatar;
            if (!System.IO.File.Exists(pathToAvatar))
            {
                pathToAvatar = Path.Combine(_webHostEnvironment.WebRootPath, "img", "NoAvatar.jpeg");
            }
           
            var fileStream = new FileStream(pathToAvatar, FileMode.Open, FileAccess.Read);

            return File(fileStream, MediaTypeNames.Image.Jpeg);
        }
    }
}
