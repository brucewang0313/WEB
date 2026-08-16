using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc7_TagHelpers.Interface
{
    public interface ICityService
    {
        List<SelectListItem> GetAllCities();
    }
}
