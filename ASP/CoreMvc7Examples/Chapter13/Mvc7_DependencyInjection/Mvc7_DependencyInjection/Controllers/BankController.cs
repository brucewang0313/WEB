
namespace Mvc7_DependencyInjection.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Balance()
        {
            ViewData["BankId"] = _bankService.BankId;
            ViewData["BankName"] = _bankService.BankName;
            ViewData["Balance"] = _bankService.AccountBalance("18072").ToString("C");

            return View();
        }

        public IActionResult InjectAction([FromServices] IBankService _bankService)
        {
            ViewData["BankId"] = _bankService.BankId;
            ViewData["BankName"] = _bankService.BankName;
            ViewData["Balance"] = _bankService.AccountBalance("18072").ToString("C");

            return View();
        }

        //Inject in View
        public IActionResult InjectView()
        {
            return View();
        }
    }
}