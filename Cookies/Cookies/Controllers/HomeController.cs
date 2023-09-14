using Cookies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            object data=String.Empty;
            if (HttpContext.Request.Cookies.ContainsKey("first_request"))
            {
                DateTime firstRequestDateTime=DateTime.Parse( HttpContext.Request.Cookies["first_request"]);
                data = $"You Visited {firstRequestDateTime.ToString()}";
            }
            else
            {
                data = "You are visiting first time";
                HttpContext.Response.Cookies.Append("first_request", System.DateTime.Now.ToString());
            }
            return View(data);
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