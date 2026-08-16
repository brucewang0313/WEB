
namespace Mvc7_DependencyInjection.Interfaces
{
    public interface IZipcodeService
    {
        string Caption { get; }
        List<ZipcodeViewModel> Cities { get; set; }
        string QueryZipcode(string cityName, string districtName);
    }
}
