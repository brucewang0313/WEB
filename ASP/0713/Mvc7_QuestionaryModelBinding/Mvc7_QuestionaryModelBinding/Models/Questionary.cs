using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;

namespace Mvc7_QuestionaryModelBinding.Models
{
    #nullable disable
    public class Questionary
    {
        [Key]
        [StringLength(50)]
        public string EventId { get; set; }
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
        [Display(Name = "地址")]
        [StringLength(255)]
        public string Address { get; set; }
        [Display(Name = "租用車款")]
        [StringLength(15)]
        public string Car { get; set; }
        [Display(Name = "數量")]
        [Range(1, 10)]
        public int Volume { get; set; }
        [Display(Name = "興趣")]
        [StringLength(50)]
        public string Habbits { get; set; }
    }
}
