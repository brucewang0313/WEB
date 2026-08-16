using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mvc7_CookieAuthentication.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult SalesReport()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult HrReport()
        {
            return View();
        }

        [Authorize(Roles = "RD")]
        public IActionResult RdReport()
        {
            return View();
        }
    }
}
