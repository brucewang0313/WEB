namespace Mvc7_Resume.ViewModels;

public class ProfileViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Introduction { get; set; }
    public DateTime Birthday { get; set; }
    public List<Education> Educations { get; set; }
    public List<Language> Languages { get; set; }
    public List<WorkExperience> WorkExperiences { get; set; }
}

public class Education
{
    public string SchoolName { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
public class Language
{
    public string Name { get; set; }
    public string Level { get; set; }
    public int Score { get; set; }
}

public class WorkExperience
{
    public string Company { get; set; }
    public string Title { get; set; }
    public decimal Salary { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

