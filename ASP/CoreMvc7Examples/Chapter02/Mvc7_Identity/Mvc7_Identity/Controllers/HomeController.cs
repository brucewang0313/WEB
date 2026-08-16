using Microsoft.AspNetCore.Mvc;
using Mvc7_Identity.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Mvc7_Identity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            if (User.Identity.Name.ToUpper() != "kevin@gmail.com".ToUpper())
            {
                //return Content($"{User.Identity.Name}無權存取此Action動作方法!");

                ViewData["Title"] = "存取禁止";  //標題
                ViewData["Message"] = $"{User.Identity.Name}無權存取此Action動作方法!";  //顯示訊息

                return View("~/Views/Shared/ResultMessage.cshtml");
            }

            return View();
        }

        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Contact()
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