using Messenger.HttpClient;
using Messenger.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Messenger.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly MessengerWebApiHttpClient _httpClient;

        public HomeController(MessengerWebApiHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public PartialViewResult Profile(int friendId)
        {
            return PartialView();
        }
    }
}