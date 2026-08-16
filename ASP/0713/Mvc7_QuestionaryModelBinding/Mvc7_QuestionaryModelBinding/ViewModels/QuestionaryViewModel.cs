using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Mvc7_QuestionaryModelBinding.ViewModels
{
    #nullable disable
    public class QuestionaryViewModel
    {
        [Required]
        [Display(Name = "姓名")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "最少需3個位元")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "電話")]
        [RegularExpression(@"^09\d{2}\-?\d{3}\-?\d{3}$", ErrorMessage = "需為09xx-xxx-xxx格式")]
        [StringLength(15)]
        public string Mobile { get; set; }

        [Required]
        [Display(Name = "電子郵件")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "性別")]
        [StringLength(8)]
        public string Gender { get; set; }
        [StringLength(15)]
        [Display(Name = "縣市")]
        public string City { get; set; }
        public List<SelectListItem> Cities { get; set; }

        [Display(Name = "地址")]
        [StringLength(255)]
        public string Address { get; set; }

        [Display(Name = "租用車款")]
        [StringLength(15)]
        public string Car { get; set; }
        public List<SelectListItem> Cars { get; set; }


        [Display(Name = "數量")]
        [Range(1, 10, ErrorMessage = "數量必須介於1-10台")]
        public int Volume { get; set; }
        [Display(Name = "興趣")]
        public List<string> Habbits { get; set; }
    }
}
