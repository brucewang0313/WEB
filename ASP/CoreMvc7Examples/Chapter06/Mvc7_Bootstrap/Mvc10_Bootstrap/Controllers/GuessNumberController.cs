using Microsoft.AspNetCore.Mvc;

namespace Mvc10_Bootstrap.Controllers
{
    public class GuessNumberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
