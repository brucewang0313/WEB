
namespace Mvc7_DependencyInjection.Controllers
{
    public class OverridingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult customHelper()
        {
            return View();
        }
    }
}