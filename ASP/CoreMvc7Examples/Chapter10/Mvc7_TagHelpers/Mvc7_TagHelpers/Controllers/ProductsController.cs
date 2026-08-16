using Microsoft.AspNetCore.Mvc;

namespace Mvc7_TagHelpers.Controllers
{
    public class ProductsController : Controller
    {
        List<Product> products { get; } = new List<Product>
        {
            new Product { ProductId = 1, Name="Mobile Phone" , Price = 8000 },
            new Product { ProductId = 2, Name="PC Computer", Price = 25000 },
            new Product { ProductId = 3, Name="NB" , Price = 35000 }
        };

        //[Route("Product/{id:int}")]
        //public IActionResult Details(int id) => View(products.FirstOrDefault(p => p.ProductId == id));

        [Route("Products/{id:int}")]
        public IActionResult Details(int id)
        {
            ViewData["Referer"] = Request.Headers["Referer"].ToString();
            return View(products.FirstOrDefault(p => p.ProductId == id));
        }

        [Route("Products/Eval", Name = "ProductsEvals")]
        public IActionResult Evaluations(int id) => View();

        [Route("Products/Avail", Name = "ProductsAvailable")]
        public IActionResult Available(int productId, bool available) => View();

        public IActionResult Index() => View(products);
    }
}
