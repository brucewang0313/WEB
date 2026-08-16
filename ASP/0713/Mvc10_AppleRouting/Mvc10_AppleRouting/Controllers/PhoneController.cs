using Microsoft.AspNetCore.Mvc;

namespace Mvc10_AppleRouting.Controllers
{
    public class PhoneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
