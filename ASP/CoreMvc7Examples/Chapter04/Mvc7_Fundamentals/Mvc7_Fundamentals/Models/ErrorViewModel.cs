namespace Mvc7_Fundamentals.Models
{
    #nullable enable
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}