using Microsoft.AspNetCore.Mvc;

namespace Mvc10_Resume.Controllers
{
    public class MixedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
