using System.ComponentModel.DataAnnotations;

namespace Messenger.Mvc.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = @"Поле ""Логин"" обязательно")]
        public string Login {get; set;}

        [Required(ErrorMessage = @"Поле ""Пароль"" обязательно")]
        public string Password { get; set;}
        [Required(ErrorMessage = @"Поле ""Повторить пароль"" обязательно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = @"Поле ""Полное Имя"" обязательно")]
        public string Name { get; set;}

        [Required(ErrorMessage = @"Поле ""Никнейм"" обязательно")]
        public string Nickname { get; set;}

        [Required(ErrorMessage = @"Поле ""Пол"" обязательно")]
        public bool IsMale { get; set;}

        [Required(ErrorMessage = @"Укажите ваш возраст")]
        [Range(16, 99, ErrorMessage = @"Ваш возраст не подходит для пользования ресурсом")]
        public int Age { get; set;}
    }
}
