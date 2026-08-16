using Microsoft.Extensions.Options;

namespace Mvc7_ConfigOptions.Controllers
{
    public class OptionsController : Controller
    {
        private readonly FoodOptions _foodOptions;
        private readonly DeviceOptions _deviceOptions;
        public OptionsController(IOptionsMonitor<FoodOptions> foodOptions, IOptionsMonitor<DeviceOptions> deviceOptions)
        {
            //Option使用前,必須在DI Container中註冊
            //利用Options Pattern從Configuration組態檔中讀入
            _foodOptions = foodOptions.CurrentValue;
            _deviceOptions = deviceOptions.CurrentValue;
        }

        public IActionResult FoodWithOptions()
        {
            return View(_foodOptions);
        }

        //Select Tag Helper with Options Pattern
        public IActionResult SelectDeviceOptions()
        {
            return View(_deviceOptions);
        }

        [HttpPost]
        public IActionResult SelectDeviceOptions(DeviceOptions deviceOptions)
        {
            return View("DeviceOptionsResult", deviceOptions);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}