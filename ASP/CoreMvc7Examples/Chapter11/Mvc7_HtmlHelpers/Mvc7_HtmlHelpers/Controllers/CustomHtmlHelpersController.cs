using Microsoft.AspNetCore.Mvc;

namespace Mvc7_HtmlHelpers.Controllers
{
    public class CustomHtmlHelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
