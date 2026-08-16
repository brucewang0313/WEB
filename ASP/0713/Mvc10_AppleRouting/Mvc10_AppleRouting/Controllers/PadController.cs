using Microsoft.AspNetCore.Mvc;

namespace Mvc10_AppleRouting.Controllers
{
    public class PadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
