using Microsoft.AspNetCore.Mvc;


namespace Mvc7_TagHelpers.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostData(int Id, string Name)
        {
            return Content($"Id : {Id}, Name : {Name}");
        }

        [Route("Person/QueryData", Name = "PersonalData")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult QueryPersonalData(int Id, string Name)
        {
            return Content($"Id : {Id}, Name : {Name}");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserInformation(int Id, string Name)
        {
            return Content($"Id : {Id}, Name : {Name}");
        }
    }
}