using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc7_TagHelpers.Controllers
{
    public class TagHelpersController : Controller
    {
        private readonly ICityService _cityService;
        public List<Hero> heros;
        public TagHelpersController(ICityService cityService)
        {
            _cityService = cityService;
            heros = new List<Hero>
                    {
                        new Hero { Name = "Elon Musk", Brief="特斯拉創辦人 伊隆·馬斯克", Photo="ElonMusk.jpg", WikiUrl="https://goo.gl/46xeXx" },
                        new Hero { Name = "Mark Zuckerberg", Brief="Facebook創辦人 馬克·祖伯克", Photo="MarkZuckerberg.jpg", WikiUrl="https://goo.gl/BktGGA" },
                        new Hero { Name = "Steve Jobs", Brief="蘋果創辦人 史提夫·賈伯斯", Photo="SteveJobs.jpg", WikiUrl="https://goo.gl/nAiX0y" },
                        new Hero { Name = "Vader", Brief="帝國元帥  維達", Photo="Vader.jpg", WikiUrl="http://bit.ly/3F5xw2w" },
                        new Hero { Name = "Darth Mual", Brief="星際大戰 達斯摩", Photo="DarthMual.jpg", WikiUrl="https://goo.gl/5obLhX"},
                        new Hero { Name = "White Twilek", Brief="星際大戰 女絕地武士Twilek", Photo="WhiteTwilek.jpg", WikiUrl="https://goo.gl/reKzAu" },
                        new Hero { Name = "Obiwan", Brief="星際大戰 歐比旺Obiwan", Photo="Obiwan.jpg", WikiUrl="http://bit.ly/33gxdgt" },
                        new Hero { Name = "Merkel", Brief="德國總理 梅克爾", Photo="Merkel.jpg", WikiUrl="http://bit.ly/33huSlv" }
                    };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult PartialTagHelper()
        {
            return View(heros);
        }

        public IActionResult ImageTagHelper()
        {
            return View();
        }


        public IActionResult AnchorTagHelper(int id = 1)
        {
            Product product = new Product { ProductId = 1 };

            return View(product);
        }

        public IActionResult FormTagHelper()
        {
            return View();
        }

        public IActionResult FormActionTagHelper()
        {
            return View();
        }

        public IActionResult InputTagHelper()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InputTagHelper([Bind("Email, Password, ConfirmPassword")] RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                TempData["Email"] = registerVM.Email;
                TempData["Password"] = registerVM.Password;

                return RedirectToAction("RegisterResult");
            }

            return View(registerVM);
        }

        public IActionResult RegisterResult()
        {
            if (!(TempData.ContainsKey("Email") && TempData.ContainsKey("Password")))
            {
                return Content("無任何資料!");
            }

            return View();
        }

        public IActionResult SelectTagHelper()
        {
            var model = new CountryViewModel();

            //插入新項目
            model.Countries.Insert(0, new SelectListItem("==請選擇國家==", ""));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectTagHelper(CountryViewModel countryVM)
        {
            if(ModelState.IsValid)
            {
                //讀取國家代碼
                string countryCode = countryVM.Country;

                //由國家代碼查詢名稱
                string country = countryVM.Countries.Where(c => c.Value == countryCode).Select(x => x.Text).FirstOrDefault();

                return RedirectToAction("DisplayCountry", new { Country = country});
            }


            return View(countryVM);
        }

        //顯示Country資訊
        public IActionResult DisplayCountry(string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                return Content("必須提供Country參數!");
            }

            ViewData["Country"] = country;

            return View();
        }

        public IActionResult SelectEnum()
        {
            var model = new CountryEnumViewModel();

            //以下是設定列舉預設值
            //model.EnumerateCountry = CountryEnum.France;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectEnum(int EnumerateCountry)
        {
            if(ModelState.IsValid)
            {
                //顯示Country名稱
                return RedirectToAction("DisplayCountry", new { Country = (CountryEnum)EnumerateCountry});
            }

            return View();
        }

        public IActionResult SelectOptionGroup()
        {
            //使用此功能, 必須先初始化CountryGroupViewModel模型類別
            var model = new CountryGroupViewModel();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //按<select asp-for="Country" >的設定,接收參數應為string Country即可
        //但為何設定成CountryGroupViewModel型別物件? 因為其Countries會含有六個國家的List<SelectListItem>
        //它可用作LINQ將國家代碼轉換成國家全名, 而不必再額外初化CountryGroupViewModel物件來取得國家資訊
        public IActionResult SelectOptionGroup(CountryGroupViewModel countryVM)
        {
            if (ModelState.IsValid)
            {
                //將國家代碼轉換成國家全名
                var country = countryVM.Countries.Where(c => c.Value == countryVM.Country).Select(x => x.Text).FirstOrDefault();

                //顯示Country名稱
                return RedirectToAction("DisplayCountry", new { Country = country });
            }

            return View();
        }

        public IActionResult MultiSelect()
        {
            var model = new CountryGroupViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MultiSelect(CountryGroupViewModel countryVM)
        {
            if (ModelState.IsValid)
            {
                //用ForEach+LINQ將國家代碼轉成名稱
                List<string> countries = new List<string>();
                countryVM.CountryCodes.ToList().ForEach((x)=>
                {
                    string countryName = countryVM.Countries.Where(c => c.Value == x).Select(s => s.Text).FirstOrDefault();
                    countries.Add(countryName);
                });

                //用LINQ語法將國家代碼轉成名稱
                var selectedCountries = countryVM.CountryCodes.Select(x => countryVM.Countries.Where(c => c.Value == x).FirstOrDefault()).Select(p => p.Text).ToList();

                TempData["CountryList"] = countries;

                return RedirectToAction("DisplayCountries");
            }

            return View();
        }

        public IActionResult DisplayCountries()
        { 
            if (!TempData.ContainsKey("CountryList"))
            {
                return Content("必須提供List集合資料");
            }

            return View((string[])TempData["CountryList"]);
        }

        //用程式新增"請選擇"
        public IActionResult NoSelection()
        {
            var model = new CountryViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NoSelection(CountryViewModel countryVM)
        {
            var model = new CountryViewModel();

            return View(model);
        }


        //用程式新增"請選擇"
        public IActionResult NoSelectionByCode()
        {
            var model = new CountryViewModel();
            model.Countries.Insert(0, new SelectListItem("==請選擇國家==", ""));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NoSelectionByCode(CountryViewModel countryVM)
        {
            return View();
        }

        public IActionResult TextareaTagHelper()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TextareaTagHelper(FeedbackViewModel feedbackVM)
        {
            if (ModelState.IsValid)
            {
                TempData["Email"] = feedbackVM.Email;
                TempData["Opinion"] = feedbackVM.Opinion.Replace("\r","").Replace("\n","<br>");

                return RedirectToAction("DisplayOpinion");
            }

            return View();
        }

        public IActionResult DisplayOpinion()
        {
            if (TempData.Count == 0)
            {
                return Content("無任何資料!");
            }

            return View();
        }

        public IActionResult ValidationTagHelper()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ValidationTagHelper(FeedbackViewModel feedbackVM)
        {
            if (ModelState.IsValid)
            {
                TempData["Email"] = feedbackVM.Email;
                TempData["Opinion"] = feedbackVM.Opinion;

                return RedirectToAction("DisplayOpinion");
            }
            else
            {
                //加入自訂錯誤訊息
                ModelState.AddModelError("ErrorReport", "輸入的資料格式內容有誤!");

                ///讀取模型驗證的錯誤訊息
                var errors = ModelState.Values.Select(err => err.Errors.FirstOrDefault().ErrorMessage).ToList();

                int idx = 1;
                errors.ForEach((error) =>
                {
                    ModelState.AddModelError($"Error{idx++}", error + ", 請重新輸入正確格式!");
                });
            }

            return View(feedbackVM);
        }

        public IActionResult CacheTagHelper()
        {
            return View();
        }

        public IActionResult DistributedCacheTagHelper()
        {
            return View();
        }



        public IActionResult CitiesCheckbox()
        {
            var cityVM = new CityViewModel();
            cityVM.Cities = _cityService.GetAllCities();

            return View(cityVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CitiesCheckbox([Bind("SelectedCities")] CityViewModel cityVM)
        {
            if (cityVM.SelectedCities != null )
            {
                return View("DisplayCities", cityVM.SelectedCities);
            }
            else
            {
                ModelState.AddModelError("ErrorReport", "必須選擇至少一個縣市!");
                cityVM.Cities = _cityService.GetAllCities();
            }

            return View(cityVM);
        }

        public IActionResult CheckboxEditorTemplate()
        {
            var cityVM = new CityViewModel();
            cityVM.Cities = _cityService.GetAllCities();

            return View(cityVM);
        }

        public IActionResult EnvironmentTagHelper()
        {
            return View();
        }
    }
}