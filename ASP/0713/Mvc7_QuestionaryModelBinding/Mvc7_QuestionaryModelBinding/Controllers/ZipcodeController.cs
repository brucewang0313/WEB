using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mvc7_QuestionaryModelBinding.Controllers
{
    #nullable disable
    public class ZipcodeController : Controller
    {
        //郵遞區號json檔
        //https://raw.githubusercontent.com/apprunner/FileStorage/master/SimpleZipCode.json

        private readonly FileLoader _fileLoader;
        public ZipcodeController(FileLoader fileLoader) 
        { 
            _fileLoader = fileLoader;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetZipcode()
        {
            string jsonZipcode = _fileLoader.LoadFile("Json", "simplezipcode.json");
            //return Content(jsonZipcode, "application/json");

            List<ZipcodeViewModel> zipcodeList = JsonConvert.DeserializeObject<List<ZipcodeViewModel>>(jsonZipcode);


            return Content(JsonConvert.SerializeObject(zipcodeList), "application/json");
            //return Json(zipcodeList);
        }

        public IActionResult GetZipcodeViewModel()
        {
            string jsonZipcode = _fileLoader.LoadFile("Json", "simplezipcode.json");

            List<ZipcodeViewModel> zipcodeList = JsonConvert.DeserializeObject<List<ZipcodeViewModel>>(jsonZipcode);

            return Content(JsonConvert.SerializeObject(zipcodeList), "application/json");

            //return Json(zipcodeList);
        }

        public IActionResult ZipcodeDropDown() 
        {
            ViewData["Zipcode"] = _fileLoader.LoadFile("Json", "simplezipcode.json");


            return View();
        }

        [HttpPost]
        public IActionResult DisplaySelectedZipcode(string city, string district,string zipcode)
        {
            ViewData["City"] = city;
            ViewData["District"] = district;
            ViewData["Zipcode"] = zipcode;

            return View();
        }
    }
}
