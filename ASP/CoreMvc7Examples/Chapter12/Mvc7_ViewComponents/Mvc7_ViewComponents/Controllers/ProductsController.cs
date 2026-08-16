using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Mvc7_ViewComponents.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //透過EF Core從資料庫讀取資料
        public IActionResult GetProductList()
        {
            return View();
        }

        public IActionResult ProductListTagHelper()
        {
            return View();
        }
    }
}