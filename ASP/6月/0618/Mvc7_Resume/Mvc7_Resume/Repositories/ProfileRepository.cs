using Mvc7_Resume.ViewModels;
using System.Collections.Generic;

namespace Mvc7_Resume.Repositories;

public class ProfileRepository
{
    private readonly List<ProfileViewModel> _profilesVM;
    private readonly ResumeContext _context;
    public ProfileRepository(ResumeContext context)
    {
        _context = context;

        _profilesVM = new List<ProfileViewModel>
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
    }

    //讀取預設第一筆
    public ProfileViewModel ReadProfile()
    {
        return _profilesVM.FirstOrDefault();
    }

    //以Id找尋資料
    public ProfileViewModel ReadProfileById(string id)
    {
        return _profilesVM.FirstOrDefault(p => p.Id == id);
    }

    //讀取所有資料
    public List<ProfileViewModel> ReadAllProfiles()
    {
        return _profilesVM;
    }

    public async Task<List<ProfileViewModel>> ReadProfolesFromDB()
    {
        //Profile Data Model
        var profiles = await _context.Profiles.ToListAsync();

        //Profile Data Model轉成ProfileViewModel
        List<ProfileViewModel> profilesVM = new List<ProfileViewModel>();

        foreach (var profile in profiles)
        {
            //將Profile屬性值指派給ProfileViewModel
            profilesVM.Add(new ProfileViewModel
            {
                Id = profile.Id,
                Name = profile.Name,
                Photo = profile.Photo,
                Email = profile.Email,
                Mobile = profile.Mobile,
                Introduction = profile.Introduction,
                Birthday = profile.Birthday,
                Languages = JsonConvert.DeserializeObject<List<Language>>(profile.Languages),
                Educations = JsonConvert.DeserializeObject<List<Education>>(profile.Educations),
                WorkExperiences = JsonConvert.DeserializeObject<List<WorkExperience>>(profile.WorkExperiences),
            });
        }
        
        return profilesVM;
    }
}