using Microsoft.AspNetCore.Mvc;

namespace Mvc10_FirstMvc.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
