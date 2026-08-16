using Microsoft.AspNetCore.Mvc;

namespace Mvc7_Resume.Controllers
{
    public class OperationController : Controller
    {
        private readonly ResumeContext _context;
        public OperationController(ResumeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> AddResumeData()
        {
            List<ProfileViewModel> profilesVM = new List<ProfileViewModel>
            {
                new ProfileViewModel
                {
                    Id = "1",
                    Name = "劉宜姍",
                    Photo = "https://static.profile.104.com.tw/profiles/eSQuCuiI8wZ/files/avatar?v=1663051158",
                    Email = "sandy@gmail.com",
                    Mobile = "0935-123-123",
                    Introduction = "24歲，現職台積部門秘書，注重時間管理:劃分重要/緊急任務，並擇優處理，協助部門提高效率，是個需面面俱到、十項全能的職位；個性活潑熱情，具十足的創意及執行力，擅於交際及溝通，身為轉學生畢業，擁有強大的適應能力",
                    Birthday = new DateTime(1995, 3, 28),
                    Languages = new List<Language> {
                        new Language { Name="國語", Level="精通", Score=95 },
                        new Language { Name="台語", Level="普通", Score=70 },
                        new Language { Name="英語", Level="精通", Score=90 }
                    },
                    Educations = new List<Education>
                    {
                        new Education { SchoolName="長庚科技大學", Department="化妝品應用系 ", StartDate=new DateTime(2018,9,1), EndDate=new DateTime(2021,6,1)},
                        new Education { SchoolName="德明財經科技大學", Department="應用外語系", StartDate=new DateTime(2017,9,1), EndDate=new DateTime(2018,6,1)}
                    },
                    WorkExperiences = new List<WorkExperience> {
                        new WorkExperience { Company="台積電", Title="部門秘書", Salary=40000, Description="做祕書工作"  , StartDate=new DateTime(2022,4,1), EndDate= DateTime.Now} ,
                        new WorkExperience { Company="台塑生醫科技股份有限公司", Title="FORTE 行銷人員", Salary=36000, Description="產品行銷人員", StartDate=new DateTime(2021,2,1), EndDate=new DateTime(2021,5,1)  } ,
                        new WorkExperience { Company="雲朗觀光股份有限公司", Title="安服人員PT", Salary=28000, Description="櫃檯接待人員", StartDate=new DateTime(2020,6,1), EndDate=new DateTime(2020,9,1)  }
                    }
                },
                new ProfileViewModel
                {
                    Id = "382",
                    Name = "Kevin",
                    Photo = "https://static.profile.104.com.tw/profiles/eSQuCuiI8wZ/files/avatar?v=1663051158",
                    Email = "kevin@gmail.com",
                    Mobile = "0935-123-123",
                    Introduction = "24歲，現職台積部門秘書，注重時間管理:劃分重要/緊急任務，並擇優處理，協助部門提高效率，是個需面面俱到、十項全能的職位；個性活潑熱情，具十足的創意及執行力，擅於交際及溝通，身為轉學生畢業，擁有強大的適應能力",
                    Birthday = new DateTime(1995, 3, 28),
                    Languages = new List<Language> {
                        new Language { Name="國語", Level="精通", Score=95 },
                        new Language { Name="台語", Level="普通", Score=70 },
                        new Language { Name="英語", Level="精通", Score=90 }
                    },
                    Educations = new List<Education>
                    {
                        new Education { SchoolName="長庚科技大學", Department="化妝品應用系 ", StartDate=new DateTime(2018,9,1), EndDate=new DateTime(2021,6,1)},
                        new Education { SchoolName="德明財經科技大學", Department="應用外語系", StartDate=new DateTime(2017,9,1), EndDate=new DateTime(2018,6,1)}
                    },
                    WorkExperiences = new List<WorkExperience> {
                        new WorkExperience { Company="台積電", Title="部門秘書", Salary=40000, Description="做祕書工作"  , StartDate=new DateTime(2022,4,1), EndDate= DateTime.Now} ,
                        new WorkExperience { Company="台塑生醫科技股份有限公司", Title="FORTE 行銷人員", Salary=36000, Description="產品行銷人員", StartDate=new DateTime(2021,2,1), EndDate=new DateTime(2021,5,1)  } ,
                        new WorkExperience { Company="雲朗觀光股份有限公司", Title="安服人員PT", Salary=28000, Description="櫃檯接待人員", StartDate=new DateTime(2020,6,1), EndDate=new DateTime(2020,9,1)  }
                    }
                },
            };

            //View Model => Data Model

            List<Profile> profiles = new List<Profile>();

            foreach (var pVM in profilesVM)
            {
                Profile profile = new Profile
                {
                     Id = pVM.Id,
                     Name = pVM.Name,
                     Photo = pVM.Photo,
                     Email = pVM.Email,
                     Mobile = pVM.Mobile,
                     Introduction = pVM.Introduction,
                     Birthday = pVM.Birthday,
                     Educations = JsonConvert.SerializeObject(pVM.Educations),
                     Languages = JsonConvert.SerializeObject(pVM.Languages),
                     WorkExperiences = JsonConvert.SerializeObject(pVM.WorkExperiences),
                };

                profiles.Add(profile);
            }

            if (profiles.Count>0)
            {
                await _context.Profiles.AddRangeAsync(profiles);
                int result = await _context.SaveChangesAsync();

                return Content($"寫入{result}筆資料成功");
            }

            return Content("未寫入任何資料!");
        }
    }
}
