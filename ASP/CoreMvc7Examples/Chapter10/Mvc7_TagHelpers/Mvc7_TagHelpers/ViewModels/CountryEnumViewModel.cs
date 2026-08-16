
namespace Mvc7_TagHelpers.ViewModels
{
    public class CountryEnumViewModel
    {
        [Required(ErrorMessage ="不得為空白，請選擇國家!")]
        public CountryEnum EnumerateCountry { get; set; }
    }

    public enum CountryEnum
    {
        [Display(Name = "美國")]
        USA = 10,
        [Display(Name = "日本")]
        Japan = 20,
        Canada = 30,
        France = 40,
        Germany = 50,
    }
}
