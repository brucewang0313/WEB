using Microsoft.AspNetCore.Mvc;

namespace Mvc7_HtmlHelpers.Controllers
{
    public class HtmlHelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SampleHelpers()
        {
            User register = new User
            {
                Id = 1001,
                Name = "奚江華",
                Nickname = "聖殿祭司",
                Email = "kevin@gmail.com",
                City = 2,
                Terms = true
            };

            ViewData.Model = register;

            return View();
        }

        [HttpGet]
        public IActionResult ValidationMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidationMessage(User user)
        {
            if (ModelState.IsValid)
            {
                return Content("成功!");
            }

            return View(user);
        }

        public IActionResult EditorFor()
        {
            RegisterDataAnnotations register = new RegisterDataAnnotations
            {
                Id = 1,
                Name = "聖殿祭司",
                Password = "myPassword",
                Email = "kevin@gmail.com",
                HomePage = "http://blog.sina.com.tw",
                Gender = Gender.Male,
                Birthday = new DateTime(1980, 6, 16),
                Birthday2 = new DateTime(1980, 6, 16),
                City = 4,
                Commutermode = "1",
                Comment = "請留下您的意見",
                Terms = true
            };

            return View(register);
        }

        [HttpPost]
        public IActionResult EditorFor(RegisterDataAnnotations register)
        {
            if (ModelState.IsValid)
            {
                return Content("成功!");
            }
            else
            {
                ModelState.AddModelError("msg1", "model資料未通過模型驗證");
            }

            return View(register);
        }

        public IActionResult HelpersBootstrap()
        {
            Register register = new Register
            {
                Id = 1,
                Name = "Kevin",
                Email = "kevin@gmail.com"
            };

            return View(register);
        }
    }
}
