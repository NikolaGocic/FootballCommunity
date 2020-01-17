using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApiFootbalCommunity
{
    public class FootballCommunityHub : Hub
    {
        public void SendMessage(String message)
        {
            Clients.All.Receive(message);
        }
    }
}