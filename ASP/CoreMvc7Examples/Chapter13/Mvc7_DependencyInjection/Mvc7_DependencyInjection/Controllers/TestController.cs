using Microsoft.AspNetCore.Mvc;

namespace Mvc7_DependencyInjection.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
