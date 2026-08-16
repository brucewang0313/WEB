
namespace Mvc7_ConfigOptions.Services
{
    public class MobileService : IDeviceService
    {
        public string DeviceType { get; } = "Mobile";
        public string ChooseCaption { get; } = "請選擇Mobile配備";

        public List<string> GetDramList() => new List<string> { "4GB", "6GB", "8GB", "12GB" };

        public List<string> GetCpuList() => new List<string> { "Qualcomm", "Samsung", "Apple" };

        public List<string> GetGpuList() => new List<string> { "AdrenoTM 640 GPU", "KryoTM 360" };

        public List<string> GetSsdList() => new List<string> { "64GB", "128GB", "256GB", "512GB" };
    }
}
