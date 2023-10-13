using AutoMapper;
using Messenger.HttpClient;

namespace Messenger.Mvc.Views.Shared.Components.FriendList
{
    public class FriendListViewModel
    {
        public IEnumerable<FriendListItemViewModel> Items { get; set; }
    }

    [AutoMap(typeof(FriendDto), ReverseMap = true)]
    public class FriendListItemViewModel
    {
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTimeOffset LastTimeOnline { get; set; }
        public bool IsOnline { get; set; }
    }
}
