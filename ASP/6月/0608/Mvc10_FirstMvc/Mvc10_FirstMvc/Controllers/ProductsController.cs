using Microsoft.AspNetCore.Mvc;
using Mvc10_FirstMvc.Views.Products;
using System.Linq.Expressions;

namespace Mvc10_FirstMvc.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexTest()
        {
            return View();
        }
        public IActionResult IndexModel()
        {
            Product car = new Product()
            {
                Id=1529,
                Title = "產品型錄",
                ProductName = "不是法拉利",
                Url="image/car.png"
            };
            return View(car);
        }
    }
}