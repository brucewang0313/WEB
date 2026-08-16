using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc7_HtmlHelpers.Data;
using Mvc7_HtmlHelpers.Models;

namespace Mvc7_HtmlHelpers.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CmsContext _context;

        public EmployeesController(CmsContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            //從資料庫讀取資料，指派給employees物件
            var employees = await _context.Employees.ToListAsync();

            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //檢查是否有員工Id的判斷
            if (id == null || _context.Employees == null)
            {
                var msgObject = new
                {
                    statuscode = StatusCodes.Status400BadRequest,
                    error = "無效的請求,必須提供Id編號!",
                    url = "The url example : /Employees/Details/5"
                };

                return new BadRequestObjectResult(msgObject);
            }

            //以Id找尋員工資料
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            //如果沒有找到員工，回傳NotFound
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Mobile,Email,Department,Title")] Employee employee)
        {
            //用ModelState.IsValid判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                //將entity加入DbSet
                _context.Employees.Add(employee);
                //_context.Add<Employee>(employee);
                //_context.Add(employee);
                //將資料異動儲存到資料庫
                await _context.SaveChangesAsync();
                //導向至Index動作方法
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Mobile,Email,Department,Title")] Employee employee)
        {
            //檢查編輯id與Entity的Id是否相等
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //更新employee實體
                    _context.Employees.Update(employee);
                    //_context.Update<Employee>(employee);
                    //_context.Update(employee);
                    await _context.SaveChangesAsync();  //將資料異動儲存到資料庫
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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

            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //檢查是否有提供id
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            //以Id找尋員工資料
            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);

            //如果沒有找到員工，回傳NotFound
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'CmsContext.Employees'  is null.");
            }

            //以Id找尋Entity，然後刪除
            var employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                //將該筆資料移除
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();  //將資料異動儲存到資料庫
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return _context.Employees.Any(e => e.Id == id);
        }
    }
}
