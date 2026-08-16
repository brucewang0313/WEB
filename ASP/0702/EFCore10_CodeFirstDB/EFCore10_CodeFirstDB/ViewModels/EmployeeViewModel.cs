using System.ComponentModel.DataAnnotations;

namespace EFCore10_CodeFirstDB.ViewModels
{
    public class EmployeeViewModel
    {
        [Display(Name="員工編號")]
        public int Id { get; set; }
        [Display(Name="員工姓名")]
        public string Name { get; set; }
        [Display(Name="員工稱謂")]
        public string Title { get; set; }
        [Display(Name="員工縣市")]
        public string City { get; set; }
        [Display(Name="員工國家")]
        public string Country { get; set; }
    }
}
