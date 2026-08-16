using Microsoft.AspNetCore.Mvc;

namespace Mvc10_AppleRouting.Controllers
{
    public class MacController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
