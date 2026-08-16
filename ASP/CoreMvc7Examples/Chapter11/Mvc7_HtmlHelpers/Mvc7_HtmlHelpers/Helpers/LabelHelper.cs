using Microsoft.AspNetCore.Html;

namespace Mvc7_HtmlHelpers.Helpers
{
    public class LabelHelper
    {
        public static IHtmlContent Label(string targetId, string labelText)
        {
            return new HtmlString(string.Format(@"<label for='{0}' class='bg-warning'>{1}</label>", targetId, labelText));
        }
    }
}