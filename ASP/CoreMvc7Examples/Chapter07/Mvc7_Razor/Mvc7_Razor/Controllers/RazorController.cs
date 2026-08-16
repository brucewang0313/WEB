using Microsoft.AspNetCore.Mvc;

namespace Mvc7_Razor.Controllers
{
    public class RazorController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public RazorController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Razor規則
        public IActionResult RazorRules()
        {
            return View();
        }

        //Razor陳述式
        public IActionResult RazorStatement()
        {
            return View();
        }

        /*
        string PortFunction(int port) =>
           port switch
           {
               80 => $"{port}, 這是HTTP使用的Port號碼",
               110 => $"{port}, 這是POP3使用的Port號碼",
               143 => $"{port}, 這是IMAP使用的Port號碼",
               443 => $"{port}, 這是HTTPS使用的Port號碼",
               587 => $"{port}, 這是SMTP使用的Port號碼",
               _ => $"{port}, 這裡沒有記載這個Port號碼的用途"
           };
         */

        public IActionResult RazorFunctions()
        {
            return View();
        }

        public IActionResult InheritsRazorPage()
        {
            AuthorViewModel author = new AuthorViewModel { Name = "聖殿祭司" };
            return View(author);
        }

        public IActionResult RazorTemplated()
        {
            return View();
        }


        public async Task<IActionResult> MakeRequest()
        {
            HttpClient client = new HttpClient();

            try
            {
                //string dataUrl = "https://raw.githubusercontent.com/apprunner/FileStorage/master/Temperature.json";
                string dataUrl = "https://www.tenlong.com.tw/zh_tw/recent_bestselling?range=7";
                HttpResponseMessage response = await client.GetAsync(dataUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                string responseContent = await client.GetStringAsync(dataUrl);

                ViewData["responseText"] = responseBody;

                return View();
            }
            catch (Exception ex)
            {
                return Content("Error Message :" + ex);
            }

            //return Content("Nothing");
        }
    }
}
