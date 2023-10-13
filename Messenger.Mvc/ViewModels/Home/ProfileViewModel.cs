namespace Messenger.Mvc.ViewModels.Home
{
    public class ProfileViewModel
    {
        public string Avatar { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
        public DateTime LastTimeOnline { get; set; }
        public bool IsOnline { get; set; }
    }
}
