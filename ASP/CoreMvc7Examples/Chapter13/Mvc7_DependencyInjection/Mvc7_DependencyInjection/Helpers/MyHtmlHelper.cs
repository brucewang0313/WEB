
namespace Mvc7_DependencyInjection.Helpers
{
    public class MyHtmlHelper 
    {
        public string Company { get; set; }
        public string Url { get; set; }

        public MyHtmlHelper() 
        {
            Company = "Code Magic碼魔法";
            Url = "https://www.codemagic.com.tw";
        }

        public string GetPhoneNumber()
        {
            return "0800-259-882";
        }
    }
}
