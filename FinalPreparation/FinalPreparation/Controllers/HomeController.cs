using FinalPreparation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalPreparation.Controllers
{
    public class HomeController : Controller
    {
        AppRepository appRepository = new AppRepository();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User model)
        {
            appRepository.AddUser(model);
            return View();
        }

        public IActionResult AllUsers()
        {
            var list = appRepository.GetAllUsers();
            return View(list);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var test = appRepository.AuthenticateUser(model);
            if (test)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult RemoveUser(string userName)
        {
            var result = appRepository.DeleteUser(userName);
            if (result)
            {
                return RedirectToAction("AllUsers");
            }
            else
            {
                return View();
            }
        }
        public IActionResult RemoveUser()
        {
            return View();
        }

    }
}