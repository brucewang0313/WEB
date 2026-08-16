using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;
using Mvc10_FormCrud.Models;
using Mvc10_FormCrud.ViewModels;
using Newtonsoft.Json;

namespace Mvc10_FormCrud.Controllers
{
    public class EmpsController : Controller
    {

        private readonly NorthwindContext _ctx;
        public EmpsController(NorthwindContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            List<string> clothes = new List<string>()
            {
                "https://cdx.lativ.com.tw/upload-v1/076009103EdmqYxPS",
                "https://cdx.lativ.com.tw/upload-v1/07600910BFdmqZxAS",
                "https://cdx.lativ.com.tw/upload-v1/07600910vFl8qZMPH",
                "https://cdx.lativ.com.tw/upload-v1/07600910h9l8IYMAS",
                "https://cdx.lativ.com.tw/upload-v1/076008236NlmqZMPS"
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(clothes);

            ViewData["JsonData"] = json;
            return View(clothes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Title,City,Country")]Employee employee)
        {

            if (ModelState.IsValid)
            {
                //加入單筆
                _ctx.Employees.Add(employee);
                //加入多筆
                //_ctx.Employees.AddRange(employee);

                await _ctx.SaveChangesAsync();
                return RedirectToAction("Index","Employees");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult CreateData()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateData(EmployeeViewModel employeeVM)
        {

            if (ModelState.IsValid)
            {
                //ViewModel => DataModel
                Employee employee = new Employee()
                {
                    LastName = employeeVM.Lname,
                    FirstName = employeeVM.Fname,
                    Title = employeeVM.Title,
                    City = employeeVM.City,
                    Country = employeeVM.Country
                };


                //加入單筆
                _ctx.Employees.Add(employee);
                //加入多筆
                //_ctx.Employees.AddRange(employee);

                await _ctx.SaveChangesAsync();
                return Content("新增資料成功");
            }
            return View(employeeVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            Employee employee = await _ctx.Employees.FindAsync(id);

            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _ctx.Update(employee);
                await _ctx.SaveChangesAsync();

                return Content("更新資料成功");
            }

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> EditData(int? id)
        {
            //Data Model
            Employee employee = await _ctx.Employees.FindAsync(id);
            //Data Model => View Model
            EmployeeViewModel employeeVM = new EmployeeViewModel()
            {
                Id = employee.EmployeeId,
                Fname = employee.FirstName,
                Lname = employee.LastName,
                Title = employee.Title,
                City = employee.City,
                Country = employee.Country
            };
            return View(employeeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditData(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                //View Model => Data Model
                Employee employee = new Employee()
                {
                    EmployeeId=employeeVM.Id,
                    LastName = employeeVM.Lname,
                    FirstName = employeeVM.Fname,
                    Title = employeeVM.Title,
                    City = employeeVM.City,
                    Country = employeeVM.Country
                };

                _ctx.Update(employee);
                await _ctx.SaveChangesAsync();

                return Content("更新資料成功");
            }

            return View(employeeVM);
        }
    }
}
