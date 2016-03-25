using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitCountDemo.Hubs
{
    public class ChatHub : Hub
    {
        public void ChatRoom(string user, string msg)
        {
            //Clients.All.recievedMessage(user, msg);
            //Clients.Caller.recievedMessage(user, msg);
            Clients.Others.recievedMessage(user, msg);
        }
    }
}