using Microsoft.AspNetCore.Mvc;
using Mvc10_JsonWebApi.Models;
using System.Reflection.Emit;

namespace Mvc10_JsonWebApi.Controllers
{
    public class JsonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LineTempJSON()
        {
            //1.X
            string[] Labels = { "1月", "2月", "3月", "4月", "5月", "6月", "7月",
                        "8月", "9月", "10月", "11月", "12月" };


            string jsonLabels = System.Text.Json.JsonSerializer.Serialize(Labels);//轉成純文字

            ViewData["JsonLabels"] = jsonLabels;

            //2.Y
            List<Location> Locations = new List<Location>
             {
                new Location {
                    City="臺北",
                    Temperature = new double[] { 16.1, 16.5, 18.5, 21.9, 25.2, 27.7, 29.6, 29.2, 27.4, 24.5, 21.5, 17.9, 23 }
                },
                new Location {
                    City="臺中",
                    Temperature = new double[] { 16.6, 17.3, 19.6, 23.1, 26.0, 27.6, 28.6, 28.3, 27.4, 25.2, 21.9, 18.1, 23.3 }
                },
                new Location {
                    City="高雄",
                    Temperature = new double[] { 19.3, 20.3, 22.6, 25.4, 27.5, 28.5, 29.2, 28.7, 28.1, 26.7, 24.0, 20.6, 25.1 }
                }
            };

            string jsonLocations = System.Text.Json.JsonSerializer.Serialize(Locations);
            ViewData["JsonLocations"] = jsonLocations;
            return View();

        }
        public IActionResult CarSalesAjaxJSON()
        {
            return View();
        }
    }
}
