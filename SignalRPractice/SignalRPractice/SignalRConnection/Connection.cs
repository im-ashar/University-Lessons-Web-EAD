using Microsoft.AspNetCore.SignalR;

namespace SignalRPractice.SignalRConnection
{
    public class Connection : Hub
    {
        public async Task SendMessage(string message, string user)
        {
            var send = message + user;
            await Clients.All.SendAsync("ReceiveMessage",send);
        }
    }
}
