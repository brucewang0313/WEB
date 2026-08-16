using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc7_QuestionaryModelBinding.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly NorthwindContext _context;
        public CategoriesController(NorthwindContext context) 
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CategoryDropDown()
        {
            //先讀Categories資料表
            List<Category> categories = await _context.Categories.ToListAsync();

            //建立SelectList
            SelectList categorySelectList = new SelectList(categories, "CategoryId", "CategoryName");

            //將SelectList資料指派給ViewData["CategoryID"], 
            //然後@Html.DropDownList("CategoryID",...)就會吃ViewData["CategoryID"]中的SelectList資料
            //@Html.DropDownList("CategoryID", null, htmlAttributes: new { @class = "form-control" })
            ViewData["CategoryID"] = categorySelectList;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> QueryCategoryProducts(int? categoryID)
        {
            var products = await _context.Products
                                         .Where(p => p.CategoryId == categoryID)
                                         .Select(p => new { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock })
                                         .ToListAsync();


            if (products.Count != 0)
            {
                var result = Json(products);
                return result;
            }

            return NotFound();
        }
    }
}
