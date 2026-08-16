using Microsoft.AspNetCore.Mvc;

namespace Mvc7_Routing.Controllers
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

        //顯示所有汽車資料 - By Category
        public async Task<IActionResult> List()
        {
            var cars = await _ctx.Cars.AsNoTracking().OrderBy(x => x.Category).ToListAsync();
            return View(cars);
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

        //與路由3「Car/Category/{cat}」對應
        //以分類查詢汽車
        public async Task<ActionResult> FindCategory(string cat)
        {
            if (string.IsNullOrEmpty(cat))
            {
                ViewData["Message"] = "請提供汽車分類名稱!";
                return View("ShowMessage");
            }

            cat = cat.Trim();

            //找出所有該類型汽車
            var cars = await (from c in _ctx.Cars
                              where c.Category == cat
                              select c).ToListAsync();

            if (cars.Count == 0)
            {
                ViewData["Message"] = "找不到此類型的車!";
                return View("ShowMessage");
            }

            return View(cars);
        }

        public async Task<IActionResult> FindId(int? Id)
        {
            if (Id == null)
            {
                ViewData["Message"] = "請提供汽車Id!";
                return View("ShowMessage");
            }

            Car car = await _ctx.Cars.FindAsync(Id);

            if (car == null)
            {
                ViewData["Message"] = "查無此Id編號汽車!";
                return View("ShowMessage");
            }

            return View(car);
        }

        //與路由5「Car/Year/{year}」對應
        //以年份找尋汽車
        public async Task<ActionResult> FindYear(int? year)
        {
            if (year == null)
            {
                ViewData["Message"] = "找車請提供年份!";
                return View("ShowMessage");
            }

            //找出所有該類型汽車
            var cars = await (from c in _ctx.Cars
                              where c.Year == year
                              orderby c.Brand
                              select c).ToListAsync();

            if (cars.Count == 0)
            {
                //return NotFound("Can not find any car of this year.");

                ViewData["Message"] = "找不到這年份的車!";
                return View("ShowMessage");
            }

            return View(cars);
        }

        //與路由6「Car/Brand-Year/{brand}-{year}」對應
        //以品牌及年份的組合找尋汽車
        public async Task<IActionResult> FindBrandYear(string brand, int year)
        {
            List<Car> cars = await (from c in _ctx.Cars
                                    where c.Brand == brand && c.Year == year
                                    select c).ToListAsync();

            if (cars.Count == 0)
            {
                ViewData["Message"] = "找不到此Brand-Year汽車";
                return View("ShowMessage");
            }

            ViewData["Header"] = brand;

            return View(cars);
        }

        //與路由7「Car/TopSales/{topnumber}」對應
        //查詢銷售前幾名汽車
        public async Task<IActionResult> TopSales(int topnumber)
        {
            //找出所有該類型汽車
            var cars = await (from c in _ctx.Cars
                              orderby c.SoldNumber descending
                              select c).Take(topnumber).ToListAsync();

            if (cars.Count == 0)
            {
                ViewData["Message"] = "找不到Top Sales數據!";
                return View("ShowMessage");
            }

            ViewData["TopSales"] = topnumber;

            return View(cars);
        }

        //8.路由結合QueryString
        //使用路由7「Car/TopSales/{topnumber}?param1=xxxx&param2=yyyy」
        public async Task<IActionResult> TopSalesQueryString(int topnumber, [FromQuery] string param1, [FromQuery] string param2)
        {
            //前面方法參數用[FromQuery]讓Model Binding自動繫結QueryString到param1, param2

            //以下利用Request.Query["key"]取得查詢字串param1, param2
            string parameter1 = Request.Query["param1"];
            string parameter2 = Request.Query["param2"];


            //找出所有該類型汽車
            var cars = await (from c in _ctx.Cars
                              orderby c.SoldNumber descending
                              select c).Take(topnumber).ToListAsync();

            if (cars.Count == 0)
            {
                ViewData["Message"] = "找不到Top Sales數據!";
                return View("ShowMessage");
            }

            ViewData["TopSales"] = topnumber;

            return View(cars);
        }

        //9.查詢價格範圍帶的汽車
        //與路由8.「Car/Price/{min}-{max}」對應
        public async Task<IActionResult> Price(decimal min, decimal max)
        {
            //如果第一個參數大於第二個參數, 則交換彼此內容值
            if (min > max)
            {
                (min, max) = (max, min);  //Tuple swap two values
            }

            List<Car> cars = await (from c in _ctx.Cars
                                    where c.Price >= min && c.Price <= max
                                    select c).ToListAsync();

            if (cars.Count == 0)
            {
                ViewData["Message"] = $"沒有符合{min}-{max}此價格範圍內的汽車";
                return View("ShowMessage");
            }

            return View(cars);
        }

        //10.查詢價格範圍帶的汽車
        //與路由9.「"Car/Pricing/{min}/{max}」對應
        public async Task<IActionResult> Pricing(decimal min, decimal max)
        {
            //如果第一個參數大於第二個參數, 則交換彼此內容值
            if (min > max)
            {
                (min, max) = (max, min);  //Tuple swap two values
            }

            List<Car> cars = await (from c in _ctx.Cars
                                    where c.Price >= min && c.Price <= max
                                    select c).ToListAsync();

            if (cars.Count == 0)
            {
                ViewData["Message"] = $"沒有符合{min}-{max}此價格範圍內的汽車";
                return View("ShowMessage");
            }

            return View(cars);
        }

        //11.查詢價格範圍帶的汽車 - 使用QueryString
        //與路由10.「Car/PriceRange」對應
        //請用Car/PriceRange?min=50000&max=80000查詢 - with QueryString
        public async Task<IActionResult> PriceRange([FromQuery] decimal min, [FromQuery] decimal max)
        {
            string minPrice = Request.Query["min"];
            string maxPrice = Request.Query["max"];

            //如果第一個參數大於第二個參數, 則交換彼此內容值     
            if (min > max)
            {
                (min, max) = (max, min);  //Tuple swap two values
            }

            List<Car> cars = await (from c in _ctx.Cars
                                    where c.Price >= min && c.Price <= max
                                    select c).ToListAsync();

            if (cars.Count == 0)
            {
                ViewData["Message"] = $"沒有符合{min}-{max}此價格範圍內的汽車";
                return View("ShowMessage");
            }

            return View(cars);
        }

        //12.查詢價格範圍帶的汽車
        //與路由10.「"Car/PriceCatchAll」對應
        //Routing + QueryString
        //請用/Car/PriceCatchAll/Suv/Price/50000-80000?color=red&oil=gasoline查詢
        public IActionResult PriceCatchAll(string catchall, [FromQuery] string color, [FromQuery] string oil)
        {
            var controller = Request.RouteValues["controller"];
            var action = Request.RouteValues["action"];

            var route = $"{controller}/{action}";

            ViewData["Route"] = route;
            ViewData["CatchAll"] = catchall;
            ViewData["Color"] = Request.Query["color"];
            ViewData["Oil"] = Request.Query["oil"];

            //string color = Request.Query["color"];
            //string oil = Request.Query["oil"];

            return View();
        }
    }
}
