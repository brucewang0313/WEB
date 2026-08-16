using EFCore10_CodeFirstDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NuGet.Protocol.Core.Types;

namespace EFCore10_CodeFirstDB.Controllers
{
    public class ProdController : Controller
    {
        private readonly NorthwindContext _context;
        public ProdController(NorthwindContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Detail()
        {
            //All
            var products = await _context.Products.ToListAsync();

            //Single Entity
            var product = await _context.Products.FindAsync(64);

            return View(product);
        }

        public async Task<IActionResult> UpdateData()
        {
            var p = await _context.Products.FindAsync(1000);

            if (p != null)
            {
                p.ProductName = "手機";
                p.UnitPrice = 3000;
                p.UnitsInStock = 56;

                var affectedRows = await _context.SaveChangesAsync();

                ViewData["AffectedRow"] = affectedRows;


                return View();
            }
            else
            {
                return Content("找不到該筆資料!");
            }
        }
        public async Task<IActionResult> CreateData()
        {
            Product p = new Product { ProductName = "筆電", UnitPrice = 5000, UnitsInStock = 10, UnitsOnOrder = 8 };

            _context.Products.Add(p);

            var affectedRows = await _context.SaveChangesAsync();

            ViewData["AffectedRow"] = affectedRows;

            return View();
        }

        public async Task<IActionResult> DeleteData()
        {
            var product = await _context.Products.FindAsync(78);

            if (product != null)
            {
                _context.Products.Remove(product);
                var affectedRows = await _context.SaveChangesAsync();

                ViewData["AffectedRow"] = affectedRows;

                return View();
            }
            else
            {
                return Content("找不到該筆資料");
            }
        }
    }
}
