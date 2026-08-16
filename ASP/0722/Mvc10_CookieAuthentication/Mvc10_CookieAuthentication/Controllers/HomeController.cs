using Microsoft.AspNetCore.Mvc;
using Mvc10_CookieAuthentication.Models;
using System.Diagnostics;

namespace Mvc10_CookieAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            if (User.Identity.Name.ToUpper() != "kevin@gmail.com".ToUpper())
            {
                //return Content($"{User.Identity.Name}無權存取此Action動作方法!");

                ViewData["Header"] = "存取禁止";  //標題
                ViewData["Message"] = $"{User.Identity.Name}無權存取此Action動作方法!";  //顯示訊息

                return View("~/Views/Shared/ResultMessage.cshtml");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
