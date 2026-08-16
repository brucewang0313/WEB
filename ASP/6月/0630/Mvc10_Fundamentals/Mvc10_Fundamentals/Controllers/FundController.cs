using Microsoft.AspNetCore.Mvc;

namespace Mvc10_Fundamentals.Controllers
{
    public class FundController : Controller
    {
        

        private readonly IWebHostEnvironment _env;
        public FundController(IWebHostEnvironment env)//為了相依性
        {
            _env = env;
            string contentRoot = env.ContentRootPath;
            string webRoot = env.WebRootPath;
        }
        public IActionResult EnvName()
        {
            ViewData["EnvName"] = _env.EnvironmentName;
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ReadAppsettings()
        {
            return View();
        }
        public IActionResult DevOptions()
        {
            return View();
        }
    }
}
