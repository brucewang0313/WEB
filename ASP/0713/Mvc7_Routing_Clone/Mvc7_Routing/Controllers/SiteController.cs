using Microsoft.AspNetCore.Mvc;


namespace Mvc7_Routing.Controllers
{
    public class SiteController : Controller
    {
        private readonly NorthwindContext _ctx;
        public SiteController(NorthwindContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
