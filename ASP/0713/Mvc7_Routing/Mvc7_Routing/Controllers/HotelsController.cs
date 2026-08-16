using Microsoft.AspNetCore.Mvc;

namespace Mvc7_Routing.Controllers
{
    public class HotelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //飯店路由結合QueryString
        //Url : Room/9527?city=Taipei&adults=1&children=2&check_in=2025-04-10&check_out=2025-04-17

        public IActionResult FindRoom(string roomid, [FromQuery] string city, [FromQuery] int adults, [FromQuery] int children, [FromQuery] string check_in, [FromQuery] string check_out)
        {
            return View();
        }
    }
}
