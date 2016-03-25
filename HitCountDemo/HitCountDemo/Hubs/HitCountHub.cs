using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitCountDemo.Hubs
{
    [HubName("HitCount")]
    public class HitCountHub : Hub
    {
        static int _hitCount = 0;
        public override System.Threading.Tasks.Task OnConnected()
        {
            _hitCount++;
            base.Clients.All.hitReceived(_hitCount);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            _hitCount--;
            base.Clients.All.hitReceived(_hitCount);
            return base.OnDisconnected(stopCalled);
        }
    }
}