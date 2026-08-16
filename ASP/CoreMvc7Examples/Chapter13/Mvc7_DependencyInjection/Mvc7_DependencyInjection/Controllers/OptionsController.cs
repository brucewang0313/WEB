
using Microsoft.Extensions.Options;

namespace Mvc7_DependencyInjection.Controllers
{
    public class OptionsController : Controller
    {
        private readonly DeviceOptions _deviceOption;
        private readonly FoodOptions _foodOptions;
        public OptionsController(IOptionsMonitor<DeviceOptions> deviceOptions, IOptionsMonitor<FoodOptions> foodOptions)
        {
            //Option使用前,必須在DI Container中註冊
            //利用Options Pattern從Configuration組態檔中讀入
            _deviceOption = deviceOptions.CurrentValue;
            _foodOptions = foodOptions.CurrentValue;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InjectSelectionWithOptions()
        {
            return View(_deviceOption);
        }

        public IActionResult FoodsOptions()
        {
            //用ViewData一一傳遞
            ViewData["Appetizer"] = _foodOptions.Appetizer;
            ViewData["MainCourse"] = _foodOptions.MainCourse;
            ViewData["Dessert"] = _foodOptions.Dessert;
            ViewData["Beverage"] = _foodOptions.Beverage;

            //或直接將_foodOptions物件以Model形式傳給View
            return View(_foodOptions);
        }

        public IActionResult ViewInjectionOption()
        {
            return View();
        }
    }
}