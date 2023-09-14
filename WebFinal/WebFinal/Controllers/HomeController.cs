using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebFinal.Models;

namespace WebFinal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var repo = new ScoreRepository();
            var totalScore = repo.GetScore();
            return View(totalScore);
        }
        public IActionResult Index2()
        {
            return View();
        }
    }
}