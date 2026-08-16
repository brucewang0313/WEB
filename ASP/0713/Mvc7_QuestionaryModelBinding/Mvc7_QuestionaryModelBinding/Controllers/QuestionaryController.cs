using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc7_QuestionaryModelBinding.Services;
using Mvc7_QuestionaryModelBinding.ViewModels;
using Newtonsoft.Json;

namespace Mvc7_QuestionaryModelBinding.Controllers
{
    public class QuestionaryController : Controller
    {
        private readonly QuestionaryContext _context;
        private readonly TransformService _transformService;
        private readonly QuestionaryService _questionaryService;

        public QuestionaryController(QuestionaryContext context, TransformService transformService, QuestionaryService questionaryService)
        {
            _context = context;
            _transformService = transformService;
            _questionaryService = questionaryService;
        }

        public async Task<IActionResult> Index()
        {
            var questionary = await _context.Questionary.ToListAsync();

            if (questionary.Count != 0)
            {
                return View(questionary);

            }

            return NotFound();
        }

        //採用HTML Helpers製作Form表單
        public IActionResult QuestionaryFormCreate()
        {
            ViewBag.City = new SelectList(new[] { "台北", "台中", "高雄" });
            ViewBag.Car = new SelectList(new[] { "CT200h", "IS300", "NX300", "RX300" });

            //ViewData["City"] = new List<SelectListItem>
            //{
            //    new SelectListItem { Text="台北", Value="1" },
            //    new SelectListItem { Text="台中", Value="2" },
            //    new SelectListItem { Text="高雄", Value="3" }
            //};

            //ViewData["Car"] =new List<SelectListItem>
            //{
            //    new SelectListItem { Text="CT200h", Value="CT200h" },
            //    new SelectListItem { Text="IS300", Value="IS300" },
            //    new SelectListItem { Text="NX300", Value="NX300" },
            //    new SelectListItem { Text="RX300", Value="RX300" }
            //};


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuestionaryFormCreate(QuestionaryViewModel questionaryVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var question = _transformService.QuestionaryViewmodelToDatamodel(questionaryVM);
                    _context.Questionary.Add(question);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    throw;
                }
            }

            ViewData["City"] = new List<SelectListItem>
            {
                new SelectListItem { Text="台北", Value="1" },
                new SelectListItem { Text="台中", Value="2" },
                new SelectListItem { Text="高雄", Value="3" }
            };

            ViewData["Car"] = new List<SelectListItem>
            {
                new SelectListItem { Text="CT200h", Value="CT200h" },
                new SelectListItem { Text="IS300", Value="IS300" },
                new SelectListItem { Text="NX300", Value="NX300" },
                new SelectListItem { Text="RX300", Value="RX300" }
            };

            return View(questionaryVM);
        }

        public IActionResult QuestionaryFormHtmlHelper()
        {
            ViewBag.City = new SelectList(new[] { "台北", "台中", "高雄" });
            ViewBag.Car = new SelectList(new[] { "CT200h", "IS300", "NX300", "RX300" });

            ViewData["City"] = new List<SelectListItem>
            {
                new SelectListItem { Text="台北", Value="1" },
                new SelectListItem { Text="台中", Value="2" },
                new SelectListItem { Text="高雄", Value="3" }
            };

            ViewData["Car"] = new List<SelectListItem>
            {
                new SelectListItem { Text="CT200h", Value="CT200h" },
                new SelectListItem { Text="IS300", Value="IS300" },
                new SelectListItem { Text="NX300", Value="NX300" },
                new SelectListItem { Text="RX300", Value="RX300" }
            };


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuestionaryFormHtmlHelper(QuestionaryViewModel questionaryVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var question = _transformService.QuestionaryViewmodelToDatamodel(questionaryVM);
                    _context.Questionary.Add(question);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    throw;
                }
            }

            return View(questionaryVM);
        }



        [HttpGet]
        public IActionResult QuestionaryFormTagHelpers()
        {
            var qVM = new QuestionaryViewModel();

            qVM.Cities = new List<SelectListItem>
            {
                new SelectListItem { Text="台北", Value="台北" },
                new SelectListItem { Text="台中", Value="台中" },
                new SelectListItem { Text="高雄", Value="高雄" }
            };

            qVM.Cars = new List<SelectListItem>
            {
                new SelectListItem { Text="CT200h", Value="CT200h" },
                new SelectListItem { Text="IS300", Value="IS300" },
                new SelectListItem { Text="NX300", Value="NX300" },
                new SelectListItem { Text="RX300", Value="RX300" }
            };

            qVM.UserName = "奚江華";
            qVM.Email = "kevin@gmail.com";

            qVM.Volume = 1;

            return View(qVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuestionaryFormTagHelpers(QuestionaryViewModel qVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //ViewModel => Data Model
                    Questionary questionary = new Questionary
                    {
                        EventId = Guid.NewGuid().ToString(),
                        UserName = qVM.UserName,
                        Mobile = qVM.Mobile,
                        Email = qVM.Email,
                        Gender = qVM.Gender,
                        City = qVM.City,
                        Address = qVM.Address,
                        Car = qVM.Car,
                        Volume = qVM.Volume,
                        Habbits = JsonConvert.SerializeObject(qVM.Habbits)
                    };

                    _context.Questionary.Add(questionary);
                    await _context.SaveChangesAsync();

                    ViewData["Header"] = "問卷調查新增";
                    ViewData["Message"] = "新增資料成功";

                    return View("ShowMessage");

                }
                catch (DbUpdateException ex)
                {
                    ViewData["Header"] = "錯誤訊息";
                    ViewData["Message"] = ex.ToString();

                    return View("ShowMessage");
                }
            }


            return View(qVM);
        }



        [HttpGet]
        public IActionResult SearchByName()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchByName(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var result = await _context.Questionary.FirstOrDefaultAsync(x => x.UserName.Contains(username));
                if (result != null)
                {
                    return View("SearchResult", result);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult QuestionayServiceRepo()
        {
            ViewData["City"] = new List<SelectListItem>
            {
                new SelectListItem { Text="台北", Value="1" },
                new SelectListItem { Text="台中", Value="2" },
                new SelectListItem { Text="高雄", Value="3" }
            };

            ViewData["Car"] = new List<SelectListItem>
            {
                new SelectListItem { Text="CT200h", Value="CT200h" },
                new SelectListItem { Text="IS300", Value="IS300" },
                new SelectListItem { Text="NX300", Value="NX300" },
                new SelectListItem { Text="RX300", Value="RX300" }
            };


            QuestionaryViewModel qVM = new QuestionaryViewModel()
            {
                UserName = "奚江華",
                Mobile = "0925155226",
                Volume = 1
            };


            return View(qVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuestionayServiceRepo(QuestionaryViewModel questionaryVM)
        {

            if (ModelState.IsValid)
            {

                bool result = await _questionaryService.AddDataAsync(questionaryVM);

                if (result)
                {
                    ViewData["ResultMessage"] = "問卷調查新增成功!";  //顯示訊息
                    ViewData["RedirectUrl"] = "/Questionary/Index";       //跳轉頁網址
                    ViewData["RedirectTime"] = 6; //倒數幾秒

                    return View("Result");
                }
                else
                {
                    ViewData["Header"] = "錯誤訊息";
                    ViewData["Message"] = "新增失敗";

                    return View("ShowMessage");
                }
            }

            ViewData["City"] = new List<SelectListItem>
            {
                new SelectListItem { Text="台北", Value="1" },
                new SelectListItem { Text="台中", Value="2" },
                new SelectListItem { Text="高雄", Value="3" }
            };

            ViewData["Car"] = new List<SelectListItem>
            {
                new SelectListItem { Text="CT200h", Value="CT200h" },
                new SelectListItem { Text="IS300", Value="IS300" },
                new SelectListItem { Text="NX300", Value="NX300" },
                new SelectListItem { Text="RX300", Value="RX300" }
            };


            return View(questionaryVM);
        }

    }
}

