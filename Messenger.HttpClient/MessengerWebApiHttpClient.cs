using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.HttpClient
{
    public class MessengerWebApiHttpClient : MessengerHttpClient
    {
        public System.Net.Http.HttpClient Client { get; set; }
        public MessengerWebApiHttpClient(System.Net.Http.HttpClient httpClient) : base(httpClient)
        {
            Client = httpClient;
        }
    }
}
