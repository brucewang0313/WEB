
namespace Mvc7_HtmlHelpers.Models
{
    public class EmployeeDataAnnotations
    {
        public int Id { get; set; }
        //[Required]
        //[StringLength(20,MinimumLength =3,ErrorMessage ="最少需3個字元!")]
        public string Name { get; set; }
        //[Required]
        //[RegularExpression(@"^\09d{2}\-?\d{3}\-?\d{3}$", ErrorMessage = "需為09xx-xxx-xxx格式")]
        public string Mobile { get; set; }
        //[Required(ErrorMessage = "請輸入Email")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //[Required(ErrorMessage = "請輸入Department")]
        public string Department { get; set; }
        //[Required(ErrorMessage = "請輸入Title")]
        public string Title { get; set; }
    }
}
