using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Messenger.Mvc.MiddleWares
{
    public class TokenMiddleWare
    {
        private readonly IConfiguration _configuration;
        private readonly RequestDelegate _next;

        public TokenMiddleWare(IConfiguration configuration, RequestDelegate next)
        {
            _configuration = configuration;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("token", out string token))
            {
                if (context.Request.Path != "/Account/Login" && context.Request.Path != "/Account/Register" && !IsValidToken(token)) 
                {
                    context.Response.Redirect("/Account/Login");
                }
            }
            else if (context.Request.Path != "/Account/Login" && context.Request.Path != "/Account/Register")
            {
                context.Response.Redirect("/Account/Login");
            }

            await _next(context);
        }

        private bool IsValidToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AuthOptions:Key"]);

            try 
            {
                tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["AuthOptions:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["AuthOptions:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true
                }, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
