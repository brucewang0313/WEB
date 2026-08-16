using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc7_Chartjs_Clone.Controllers
{
    public class ChartsDBController : Controller
    {
        private readonly NorthwindContext _ctx;
        public ChartsDBController(NorthwindContext ctx) 
        {
            _ctx = ctx;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        //從Products資料表中讀取單價前10高的產品,繪製Bar長條圖
        //1.X軸:產品名稱
        //2.Y軸:單價
        public IActionResult Top10Products()
        {
            //1.讀取單價前10高的Products產品資訊
            List<Product> products = _ctx.Products.OrderByDescending(p => p.UnitPrice)
                                                  .Select(p => p)
                                                  .Take(10).ToList();


            List<ProductViewModel> productsVM = _ctx.Products.OrderByDescending(p=>p.UnitPrice)
                           .Select(p=> new ProductViewModel { Name= p.ProductName, Price=p.UnitPrice})
                           .Take(10).ToList();

            List<ProductViewModel> top10ProductsVM = (from p in _ctx.Products
                      orderby p.UnitPrice descending
                      select new ProductViewModel { Name = p.ProductName, Price=p.UnitPrice }).Take(10).ToList();

            string json = JsonSerializer.Serialize(top10ProductsVM);

            ViewData["Products"] = json;

            return View();
        }

        public async Task<IActionResult> Top10()
        {
            //1.讀取單價前10高的Products產品資訊
            
            List<Product> products = await (_ctx.Products.OrderByDescending(p => p.UnitPrice)
                                       .Select(p => p)
                                       .Take(10)).ToListAsync();


            List<ProductViewModel> productsVM = await (_ctx.Products.OrderByDescending(p => p.UnitPrice)
                           .Select(p => new ProductViewModel { Name = p.ProductName, Price = p.UnitPrice })
                           .Take(10)).ToListAsync();

            List<ProductViewModel> top10ProductsVM = await (  from p in _ctx.Products
                                                      orderby p.UnitPrice descending
                                                      select new ProductViewModel { Name = p.ProductName, Price = p.UnitPrice }).Take(10).ToListAsync();

            string json = JsonSerializer.Serialize(top10ProductsVM);

            ViewData["Products"] = json;

            return View();
        }
    }
}
