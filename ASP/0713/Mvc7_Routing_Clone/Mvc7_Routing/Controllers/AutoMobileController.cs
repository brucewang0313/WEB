using Microsoft.AspNetCore.Mvc;

namespace Mvc7_Routing_Clone.Controllers
{
    public class AutoMobileController : Controller
    {
        private readonly CarContext _ctx;

        public AutoMobileController(CarContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Repair()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        //與路由2「Car/Brand/{brand}」對應
        //以品牌找尋汽車
        public async Task<IActionResult> FindBrand(string brand)
        {
            List<Car> cars = null;

            if (string.IsNullOrEmpty(brand) || brand.Trim().ToUpper() == "ALL")
            {
                //找出所有品牌汽車
                cars = await (from c in _ctx.Cars
                              select c).ToListAsync();

                ViewData["Header"] = "所有品牌汽車";
            }
            else
            {
                //找出該品牌汽車
                cars = await (from c in _ctx.Cars
                              where c.Brand == brand
                              select c).ToListAsync();

                //ViewData["Header"] = cars[0].Brand;
            }

            if (cars.Count == 0)
            {
                //ViewData["ResultMessage"] = "找不到此品牌汽車";
                //return View("Result");

                return new StatusCodeResult(400);
                //return new StatusCodeResult((int)HttpStatusCode.Ambiguous);

            }

            return View(cars);
        }
    }
}
