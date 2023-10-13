using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Mvc.Controllers
{
    [Authorize]
    public class PhotosController : MessengerController
    {
        public IActionResult GetAvatar(int id)
        {
            return View();
        }
    }
}
