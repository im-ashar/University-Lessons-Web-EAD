using Microsoft.AspNetCore.SignalR;
using WebFinal.Models;

namespace WebFinal.SignalRHub
{
    public class AppHub : Hub
    {
        public void Add(string addScore)
        {
            var repo = new ScoreRepository();
            var total=repo.AddScore(int.Parse(addScore));
            Clients.All.SendAsync("Display", total);
        }
    }
}
