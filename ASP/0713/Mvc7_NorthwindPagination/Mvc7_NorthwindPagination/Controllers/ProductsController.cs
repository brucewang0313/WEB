using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc7_NorthwindPagination.Controllers
{
    public class ProductsController : Controller
    {
        private readonly NorthwindContext _ctx;
        private static int totalRows = -1;
        public ProductsController(NorthwindContext ctx)
        {
            _ctx = ctx;

            if (totalRows == -1)
            {
                totalRows = _ctx.Products.Count();   //計算總筆數
            }
        }

        public async Task<IActionResult> Index(int id=1)
        {
            int activePage = id; //目前所在active頁
            int pageRows = 10;    //每頁顯示幾筆資料

            //計算Page頁數
            int Pages = 0;
            if (totalRows % pageRows ==0)
            {
                Pages = totalRows / pageRows;
            }
            else
            {
                Pages = (totalRows / pageRows) + 1;
            }

            int startRow = (activePage - 1) * pageRows; //起始記錄Index

            var products = await _ctx.Products.OrderBy(x=>x.ProductId)
                            .Skip(startRow).Take(pageRows).ToListAsync();

            ViewData["ActivePage"] = activePage; //Activec分頁碼
            ViewData["Pages"] = Pages; //總分頁數

            return View(products);
        }
    }
}
