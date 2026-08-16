using Mvc7_Resume.Repositories;
using Mvc7_Resume.ViewModels;

namespace Mvc7_Resume.Services
{
    //https://profile.104.com.tw/
    //https://profile.104.com.tw/eSQuCuiI8wZ/about/
    public class ProfileService
    {
        private readonly ProfileViewModel _profileVM;
        private readonly List<ProfileViewModel> _profilesVM;
        private readonly ProfileRepository _profileRepo;
        public ProfileService(ProfileRepository profileRepo)
        {
            //單筆
            ProfileViewModel profileVM = new ProfileViewModel
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
            };

            //多筆
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
                    Id = "2",
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

            _profileVM = profileVM;
            _profilesVM = profilesVM;

            _profileRepo = profileRepo;
        }
        public ProfileViewModel GetProfile()
        {
            return _profileVM;
        }

        public ProfileViewModel GetProfile(string id)
        {
            return _profilesVM.FirstOrDefault(p=>p.Id==id);
        }

        public List<ProfileViewModel> GetAllProfiles()
        {
            return _profileRepo.ReadAllProfiles();
        }

        public async Task<List<ProfileViewModel>> GetProfilesFromDB()
        {
            return await _profileRepo.ReadProfolesFromDB();
        }
    }
}
