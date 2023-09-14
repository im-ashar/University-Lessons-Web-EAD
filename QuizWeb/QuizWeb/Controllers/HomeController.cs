using Microsoft.AspNetCore.Mvc;
using QuizWeb.Models;
using System.Diagnostics;
using User = QuizWeb.Models.User;

namespace QuizWeb.Controllers
{
    public class HomeController : Controller
    {
        public static List<User> users = new List<User>();
        
        public IActionResult Index()
        {
            users.Add(new User { Id = Guid.NewGuid() });
            users.Add(new User { Id = Guid.NewGuid() });
            users.Add(new User { Id = Guid.NewGuid() });

            users.Add(new User { Id = Guid.NewGuid() });
            users.Add(new User { Id = Guid.NewGuid() });
            users.Add(new User { Id = Guid.NewGuid() });
            users.Add(new User { Id = Guid.NewGuid() });
            users.Add(new User { Id = Guid.NewGuid() });
            users.Add(new User { Id = Guid.NewGuid() });
            users.Add(new User { Id = Guid.NewGuid() });
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}