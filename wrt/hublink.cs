
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace wrt
{
    public class hublink : Hub
    {

        // แบบที่ 1
        public async Task display_division_server(int is_mode, string[] data)
        {
            await Clients.All.display_division_client(is_mode,  data);
        }


        public async Task send_message(string msg)
        {
               await Clients.All.send_message(msg);
        }

        //static
        public static void get_data_chat(string data)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<hublink>();
            context.Clients.All.get_data_chat(data);
        }

    }
}