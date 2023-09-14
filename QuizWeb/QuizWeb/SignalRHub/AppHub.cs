using Microsoft.AspNetCore.SignalR;
using QuizWeb.Controllers;
using QuizWeb.Models;

namespace QuizWeb.SignalRHub
{
    public class AppHub:Hub
    {
        public string SendList(string userId)
        {
            bool found = false;
            foreach(var user in HomeController.users.ToList())
            {
                if(userId == user.Id.ToString())
                {
                    found = true;
                    HomeController.users.Remove(user);
                    break;
                }
            }
            if(!found)
            {
                return null;
            }
            else
            {
                return userId;
            }
        }
        public async Task Send(string id)
        {
            var id2=SendList(id);
            if(id2 != null)
            {
                await Clients.All.SendAsync("Receive", id2);
            }
            else
            {
                await Clients.All.SendAsync("NotFound", "Error");
            }
        }
    }

    
}
