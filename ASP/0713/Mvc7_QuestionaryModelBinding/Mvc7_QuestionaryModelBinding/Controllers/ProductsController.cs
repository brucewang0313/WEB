using Microsoft.AspNetCore.Mvc;

namespace Mvc7_QuestionaryModelBinding.Controllers
{
    public class ProductsController : Controller
    {
        private readonly NorthwindContext _context;
        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SearchProducts(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim();

                var products = await _context.Products.Where(p => p.ProductName.Contains(keyword)).AsNoTracking().ToListAsync();

                if (products.Count > 0)
                {
                    return View(products);
                }
            }

            ViewData["Header"] = "搜尋結果";
            ViewData["Message"] = $"以{keyword}關鍵字搜尋不到任何相關的產品資料";

            return View("ShowMessage");
        }
    }
}
