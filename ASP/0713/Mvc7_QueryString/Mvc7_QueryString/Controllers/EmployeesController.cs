using Microsoft.AspNetCore.Mvc;
using Mvc7_QueryString.ViewModels;
using System.Diagnostics.Metrics;

namespace Mvc7_QueryString.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QueryEmployees()
        {
            string country = Request.Query["country"];
            string title = Request.Query["title"];

            ViewData["country"] = country;
            ViewData["title"] = title;


            return new ObjectResult(new { StatusCode=200, Country=country, Title = title }) ;
        }

        public IActionResult FindEmployees([FromQuery] string country, [FromQuery] string title) 
        {
            ViewData["Country"] = country;
            ViewData["JobTitle"] = title;

            return View();
        }

        public IActionResult SearchEmployees(QueryViewModel queryVM)
        {
            ViewData["Country"] = queryVM.Country;
            ViewData["Title"] = queryVM.Title;

            return View();
        }
    }
}
