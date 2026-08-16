using Microsoft.AspNetCore.Mvc;
using Mvc7_QueryString.ViewModels;

namespace Mvc7_QueryString.Controllers
{
    public class HotelsController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        //從MakeAnchors.cshtml檢視超連結導向QueryHotel()及FindHotel()方法
        public IActionResult MakeAnchors()
        {
            return View();
        }

        //QueryString讀取方式一
        public IActionResult QueryHotel()
        {
            string city = Request.Query["city"];
            string price = Request.Query["price"];
            string network = Request.Query["network"];

            ViewData["City"] = city;
            ViewData["Price"] = price;
            ViewData["Network"] = network;

            return View();
        }

        //QueryString讀取方式二
        public IActionResult FindHotel([FromQuery] string city,
            [FromQuery] string price, [FromQuery] string network)
        {
            //todo...

            ViewData["City"] = city;
            ViewData["Price"] = price;
            ViewData["Network"] = network;

            return View();
        }

        public IActionResult SearchHotel([FromQuery] QueryStringViewModel queryVM)
        {
            ViewData["City"] = queryVM.city;
            ViewData["Price"] = queryVM.price;
            ViewData["Network"] = queryVM.network;

            return View();
        }
    }
}
