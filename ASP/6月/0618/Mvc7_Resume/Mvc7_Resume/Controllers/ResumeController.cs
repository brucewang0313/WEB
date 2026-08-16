using Microsoft.AspNetCore.Mvc;
using Mvc7_Resume.Services;
using Mvc7_Resume.ViewModels;
using Newtonsoft.Json;

namespace Mvc7_Resume.Controllers
{
    //https://profile.104.com.tw/
    //https://profile.104.com.tw/eSQuCuiI8wZ/about/
    public class ResumeController : Controller
    {
        private readonly ProfileService _profileService;
        public ResumeController(ProfileService profileService) 
        {
            _profileService = profileService;
        }


        //直白式寫法
        public IActionResult Profile()
        {
            ProfileViewModel profileVM = new ProfileViewModel
            {
                Id = "1",
                Name = "劉宜姍",
                Photo = "https://static.profile.104.com.tw/profiles/eSQuCuiI8wZ/files/avatar?v=1663051158",
                Email = "sandy@gmail.com",
                Mobile = "0935-123-123",
                Introduction = "24歲，現職台積部門秘書，注重時間管理:劃分重要/緊急任務，並擇優處理，協助部門提高效率，是個需面面俱到、十項全能的職位；個性活潑熱情，具十足的創意及執行力，擅於交際及溝通，身為轉學生畢業，擁有強大的適應能力",
                Birthday = new DateTime(1995, 3, 28),
                Educations = new List<Education>
                {
                    new Education { SchoolName="長庚科技大學", Department="化妝品應用系 ", StartDate=new DateTime(2018,9,1), EndDate=new DateTime(2021,6,1)},
                    new Education { SchoolName="德明財經科技大學", Department="應用外語系", StartDate=new DateTime(2017,9,1), EndDate=new DateTime(2018,6,1)}
                },
                Languages = new List<Language> {
                    new Language { Name="國語", Level="精通", Score=95 },
                    new Language { Name="台語", Level="普通", Score=70 },
                    new Language { Name="英語", Level="精通", Score=90 }
                },
                WorkExperiences = new List<WorkExperience> {
                    new WorkExperience { Company="台積電", Title="部門秘書", Salary=40000, Description="做祕書工作"  , StartDate=new DateTime(2022,4,1), EndDate= DateTime.Now} ,
                    new WorkExperience { Company="台塑生醫科技股份有限公司", Title="FORTE 行銷人員", Salary=36000, Description="產品行銷人員", StartDate=new DateTime(2021,2,1), EndDate=new DateTime(2021,5,1)  } ,
                    new WorkExperience { Company="雲朗觀光股份有限公司", Title="安服人員PT", Salary=28000, Description="櫃檯接待人員", StartDate=new DateTime(2020,6,1), EndDate=new DateTime(2020,9,1)  }
                }
            };

            string json = """  {"Id":"1","Name":"劉宜姍","Photo":"https://static.profile.104.com.tw/profiles/eSQuCuiI8wZ/files/avatar?v=1663051158","Email":"sandy@gmail.com","Mobile":"0935-123-123","Introduction":"24歲，現職台積部門秘書，注重時間管理:劃分重要/緊急任務，並擇優處理，協助部門提高效率，是個需面面俱到、十項全能的職位；個性活潑熱情，具十足的創意及執行力，擅於交際及溝通，身為轉學生畢業，擁有強大的適應能力","Birthday":"1995-03-28T00:00:00","Educations":[{"SchoolName":"長庚科技大學","Department":"化妝品應用系 ","StartDate":"2018-09-01T00:00:00","EndDate":"2021-06-01T00:00:00"},{"SchoolName":"德明財經科技大學","Department":"應用外語系","StartDate":"2017-09-01T00:00:00","EndDate":"2018-06-01T00:00:00"}],"Languages":[{"Name":"國語","Level":"精通","Score":95},{"Name":"台語","Level":"普通","Score":70},{"Name":"英語","Level":"精通","Score":90}],"WorkExperiences":[{"Company":"台積電","Title":"部門秘書","Salary":40000.0,"Description":"做祕書工作","StartDate":"2022-04-01T00:00:00","EndDate":"2023-03-16T15:19:31.7643367+08:00"},{"Company":"台塑生醫科技股份有限公司","Title":"FORTE 行銷人員","Salary":36000.0,"Description":"產品行銷人員","StartDate":"2021-02-01T00:00:00","EndDate":"2021-05-01T00:00:00"},{"Company":"雲朗觀光股份有限公司","Title":"安服人員PT","Salary":28000.0,"Description":"櫃檯接待人員","StartDate":"2020-06-01T00:00:00","EndDate":"2020-09-01T00:00:00"}]} """;

            ProfileViewModel pVM = JsonConvert.DeserializeObject<ProfileViewModel>(json);

            string jsonProfile = Newtonsoft.Json.JsonConvert.SerializeObject(profileVM);

            ViewData["profile"] = jsonProfile;


            return View(profileVM);
        }


        //僅Service
        public IActionResult ProfileService()
        {

            //var profile = _profileService.getProfile();

            var profile = _profileService.GetProfile("1");

            string jsonProfile = Newtonsoft.Json.JsonConvert.SerializeObject(profile);

            ViewData["profile"] = jsonProfile;

            return View(profile);
        }

        //Service ＋ Repository
        public IActionResult ProfileServiceRepository() 
        {

            var profilesVM = _profileService.GetAllProfiles();


            return View(profilesVM.FirstOrDefault());
        }

        //Service ＋ Repository from DB
        public async Task<IActionResult> ProfileServiceRepositoryDB()
        {

            List<ProfileViewModel> profilesVM = await _profileService.GetProfilesFromDB();


            return View(profilesVM);
        }
    }
}
