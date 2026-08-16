namespace Mvc7_ConfigOptions.Interfaces
{
    public interface IDeviceService
    {
        string DeviceType { get; }
        string ChooseCaption { get; }
        List<string> GetDramList();
        List<string> GetCpuList();
        List<string> GetGpuList();
        List<string> GetSsdList();
    }
}
