using Microsoft.AspNetCore.Mvc;

namespace Mvc7_TagHelpers.Controllers
{
    public class CustomTagHelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AnchorEmail()
        {
            return View();
        }

        public IActionResult Email()
        {
            return View();
        }

        public IActionResult EmailAsynchrous()
        {
            return View();
        }
    }
}
