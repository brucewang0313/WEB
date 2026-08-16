using Microsoft.AspNetCore.Mvc;

namespace Mvc7_QuestionaryModelBinding.Controllers
{
    public class SiteController : Controller
    {
        private readonly NorthwindContext _context;
        public SiteController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchProductsByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                ViewData["Header"] = "關鍵字不得為空字串";
                ViewData["Message"] = "請提供產品關字";

                return View("ShowMessage");
            }

            keyword = keyword.Trim();
            //return RedirectToAction("SearchProducts", "Products", new { @keyword = keyword });

            List<Product> products = await _context.Products
                .Where(p => p.ProductName.ToUpper().Contains(keyword.ToUpper())).ToListAsync();

            if (products.Count == 0)
            {
                ViewData["Header"] = "搜尋結果";
                ViewData["Message"] = $"以{keyword}關鍵字搜尋不到任何相關的產品資料";

                return View("ShowMessage");
            }

            return View("~/Views/Products/ListProducts.cshtml", products);

        }
    }
}
