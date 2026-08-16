using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        [HttpGet, HttpPost]
        public async Task<IActionResult> SearchKeyword(string keyword)
        {
            var product = await _ctx.Products.FirstOrDefaultAsync(x => x.ProductName.ToUpper() == keyword.ToUpper());

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchProductsByKeyword(string keyword)
        {
            List<Product> products = await _ctx.Products
                .Where(p => p.ProductName.ToUpper().Contains(keyword.Trim().ToUpper()))
                .ToListAsync();

            return View("~/Views/Products/ListProducts.cshtml", products);
        }

        [HttpGet, ActionName("SearchProductsByKeyword")]
        public async Task<IActionResult> SearchProductsByKey(string keyword)
        {
            List<Product> products = await _ctx.Products
                .Where(p => p.ProductName.ToUpper().Contains(keyword.Trim().ToUpper()))
                .ToListAsync();

            return View("~/Views/Products/ListProducts.cshtml", products);
        }
    }
}
