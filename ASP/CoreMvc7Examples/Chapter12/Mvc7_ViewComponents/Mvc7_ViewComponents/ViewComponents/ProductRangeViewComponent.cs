using Microsoft.AspNetCore.Mvc;

namespace Mvc7_ViewComponents.ViewComponents
{
    public class ProductRangeViewComponent : ViewComponent
    {
        private readonly DatabaseContext _context;

        public ProductRangeViewComponent(DatabaseContext context)
        {
            _context = context;
        }

        //透過EF Core讀取資料庫 參數lower是最低價格, higher是最高價格
        public async Task<IViewComponentResult> InvokeAsync(decimal lower, decimal higher)
        {
            var products = from p in _context.Products
                           where p.Price >= lower && p.Price <= higher
                           orderby p.Price descending
                           select p;

            return View(await products.ToListAsync());
        }
    }
}
