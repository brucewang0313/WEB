
namespace Mvc7_DependencyInjection.Interfaces
{
    public interface ICityService
    {
        string ChooseCaption { get; }
        List<CityViewModel> Cities { get; set; }
        List<string> GetCityNames();
        List<SelectListItem> GetCitySelectListItem();
    }
}
