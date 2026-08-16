using System.ComponentModel.DataAnnotations;

namespace Mvc10_FormCrud.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage= "請輸入LastName")]
        [StringLength(20,MinimumLength =5,ErrorMessage ="最少需要5個字元")]
        public string Lname { get; set; }
        [Required(ErrorMessage= "請輸入LastName")]
        [StringLength(10,MinimumLength =5,ErrorMessage ="最少需要5個字元")]
        public string Fname { get; set; }
        [Required(ErrorMessage= "請輸入Title")]
        public string Title { get; set; }
        [Required(ErrorMessage= "請輸入City")]
        public string City { get; set; }
        [Required(ErrorMessage= "請輸入Country")]
        public string Country { get; set; }
        
    }

}
