using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc7_TagHelpers.ViewModels
{
    public class CityViewModel
    {
        public List<SelectListItem> Cities { get; set; } 

        [Required(ErrorMessage = "SelectedCities欄位不得為空白")]
        public List<string> SelectedCities { get; set; }
    }
}
