using Microsoft.AspNetCore.Mvc;

namespace Mvc7_FirstMVC.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
