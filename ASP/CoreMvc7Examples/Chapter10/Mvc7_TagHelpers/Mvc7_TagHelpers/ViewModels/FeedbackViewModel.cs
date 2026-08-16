
namespace Mvc7_TagHelpers.ViewModels
{
    public class FeedbackViewModel
    {
        [Display(Name = "顧客Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        [StringLength(50, MinimumLength = 10)]
        [RegularExpression(@"^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$")]
        public string Email { get; set; }

        [Display(Name = "顧客意見")]
        [Required]
        [StringLength(255)]
        public string Opinion { get; set; }
    }
}
