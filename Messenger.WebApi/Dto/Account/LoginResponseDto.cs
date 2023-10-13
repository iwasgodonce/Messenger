namespace Messenger.WebApi.Dto.Account
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string Login { get; set; }
    }
}
