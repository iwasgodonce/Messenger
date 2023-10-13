using AutoMapper;
using Messenger.HttpClient;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Mvc.Views.Shared.Components.FriendList
{
    public class FriendListViewComponent : ViewComponent
    {
        private readonly MessengerWebApiHttpClient _httpClient;
        private readonly IMapper _mapper;

        public FriendListViewComponent(MessengerWebApiHttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var token = this.Request.Cookies["token"];
            _httpClient.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var friends = await _httpClient.GetAllAllAsync(null);
            var model = new FriendListViewModel
            {
                Items = _mapper.Map<IEnumerable<FriendListItemViewModel>>(friends)
            };
            return View(model);
        }
    }
}
