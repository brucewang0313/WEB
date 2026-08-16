using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc7_ViewComponents.Data;
using Mvc7_ViewComponents.Models;

namespace Mvc7_ViewComponents.Controllers
{
    public class SalesController : Controller
    {
        private readonly DatabaseContext _context;

        public SalesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
              return View(await _context.SalesReport.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesReport == null)
            {
                return NotFound();
            }

            var sales = await _context.SalesReport
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesId,ProductId,Name,Price,SalesVolume")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sales);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesReport == null)
            {
                return NotFound();
            }

            var sales = await _context.SalesReport.FindAsync(id);
            if (sales == null)
            {
                return NotFound();
            }
            return View(sales);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesId,ProductId,Name,Price,SalesVolume")] Sales sales)
        {
            if (id != sales.SalesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesExists(sales.SalesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sales);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesReport == null)
            {
                return NotFound();
            }

            var sales = await _context.SalesReport
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesReport == null)
            {
                return Problem("Entity set 'DatabaseContext.SalesReport'  is null.");
            }
            var sales = await _context.SalesReport.FindAsync(id);
            if (sales != null)
            {
                _context.SalesReport.Remove(sales);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //產品銷售排行榜
        public async Task<IActionResult> TopRanking()
        {
            var salesList = await _context.SalesReport.ToListAsync();

            return View(salesList.OrderByDescending(x => x.SalesVolume));
        }

        private bool SalesExists(int id)
        {
          return _context.SalesReport.Any(e => e.SalesId == id);
        }
    }
}
