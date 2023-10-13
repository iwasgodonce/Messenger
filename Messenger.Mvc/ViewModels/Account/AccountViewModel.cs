using System.ComponentModel.DataAnnotations;

namespace Messenger.Mvc.ViewModels.Account
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = @"Поле ""Логин"" обязательно")]
        public string Login { get; set; }

        [Required(ErrorMessage = @"Поле ""Пароль"" обязательно")]
        public string Password { get; set; }
    }
}
