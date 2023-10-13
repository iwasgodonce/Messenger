using Messenger.HttpClient;
using Messenger.Mvc.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace Messenger.Mvc.Controllers
{
    public class AccountController : MessengerController
    {
        private readonly MessengerWebApiHttpClient _httpClient;

        public AccountController(MessengerWebApiHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(input);
                }

                var response = await _httpClient.LoginAsync(new LoginDto
                {
                    Login = input.Login,
                    Password = input.Password,
                });

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, response.Login));
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, principal);

                Response.Cookies.Append("token", response.Token, new CookieOptions
                {
                    Expires = response.Expires
                });

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Логин и/или пароль введены неверно";
                return View(input);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(input);
                }

                await _httpClient.CreateAsync(new CreateUserDto
                {
                    Name = input.Name,
                    NickName = input.Nickname,
                    Age = input.Age,
                    IsMale = input.IsMale,
                    Login = input.Login,
                    Password = input.Password,
                });

                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                return View(input);
            }
        }
    }
}
