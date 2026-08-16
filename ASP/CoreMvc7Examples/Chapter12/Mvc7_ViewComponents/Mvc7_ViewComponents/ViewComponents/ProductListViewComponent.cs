
using Microsoft.AspNetCore.Mvc;

namespace Mvc7_ViewComponents.ViewComponents
{
    public class ProductListViewComponent :　ViewComponent 
    {
        private readonly DatabaseContext _context;

        public ProductListViewComponent(DatabaseContext context)
        {
            _context = context;
        }

        //透過EF Core讀取資料庫, TopPricing參數是指價格前幾名
        public async Task<IViewComponentResult> InvokeAsync(int TopPricing)
        {

            var products = await _context.Products
                                         .OrderByDescending(p => p.Price)
                                         .Take(TopPricing)
                                         .ToListAsync();

            return View(products);
            //return View("MyProduct", products);
        }
    }
}
