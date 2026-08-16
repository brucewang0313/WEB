using Microsoft.AspNetCore.Mvc;

namespace Mvc7_Routing.Controllers
{
    public class RouteDataController : Controller
    {
        public IActionResult Index()
        {
            var route = RouteData;

            //從路由讀取controller及action名稱
            string controllerName = RouteData.Values["controller"].ToString();
            string actionName = RouteData.Values["action"].ToString();

            return View();
        }
    }
}
