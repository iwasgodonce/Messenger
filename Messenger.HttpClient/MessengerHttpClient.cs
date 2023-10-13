using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.HttpClient
{
    public partial class MessengerHttpClient
    {
        public MessengerHttpClient(System.Net.Http.HttpClient httpClient) : this(null, httpClient)
        {
        }
    }
}
