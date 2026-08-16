using Microsoft.AspNetCore.Mvc;

namespace Mvc10_AppleRouting.Controllers
{
    public class WatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
