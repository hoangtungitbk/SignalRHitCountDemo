# SignalRHitCountDemo
1. Create Empty MVC project
2. Open Nuget to install Microsoft ASP.NET SignalR
3. Create Owin Start Up Class and named as Startup.cs
public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }

4. Create folder to store Hub Classes named 'Hubs'
5. Add Class HitCountHub : Microsoft.AspNet.SignalR.Hub
6. static int _hitCount = 0; //Store the current number of users hit the application
7. Override OnConnected() method
Everytime when new user open browser and hit to the web address. 
the _hitCount number will be increased.
After that the server will fire the method 'hitRecieved(_hitCount)' to 
all clients who already connected to the web server hub.
So all clients who handel this method will gonna do what need to do.

public override System.Threading.Tasks.Task OnConnected()
        {
            _hitCount++;
            base.Clients.All.hitReceived(_hitCount);
            return base.OnConnected();
        }

8. Add Default.html page

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <div id="hitCount" style="font-size:72pt;"></div>
    
    <!--Jquery library must be included before signalR-->
    <script src="Scripts/jquery-1.6.4.js"></script>
    <script src="Scripts/jquery.signalR-2.2.0.js"></script>
    <script>
        $(function () {
            var conn = $.hubConnection();
            //var hub = conn.createHubProxy('hitCountHub'); //the hub class name in camel notation. But .Net class name will be Pascal
            var hub = conn.createHubProxy('HitCount');
            hub.on('hitReceived', function (count) {
                //hitReceived : the dynamic expression method name was defined in hub server
                //count : parameter of the method
                //this method implement how to handle the result on client size
                $('#hitCount').text(count);
            });
            conn.start();
            
        });
    </script>
</body>
</html>

------------------------------------
Chat:
1. Create ChatHub
2. Create html file
