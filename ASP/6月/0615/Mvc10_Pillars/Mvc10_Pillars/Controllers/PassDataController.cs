using Microsoft.AspNetCore.Mvc;

namespace Mvc10_Pillars.Controllers
{
    public class PassDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PassViewData()
        {
            ViewData["Name"] = "Bruce";
            ViewData["Age"] = 33;
            ViewData["Single"] = true;
            return View();
        }
    }
}
