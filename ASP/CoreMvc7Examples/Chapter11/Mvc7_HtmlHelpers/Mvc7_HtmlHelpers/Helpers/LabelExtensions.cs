using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc7_HtmlHelpers.Helpers
{
    public static class LabelExtensions
    {
        public static IHtmlContent Label(this IHtmlHelper helper, string targetId, string labelText, string nothing, string empty)
        {
            return new HtmlString(string.Format(@"<label for='{0}'><span class='badge bg-success'>{1}<span></label>", targetId, labelText));
            //return new HtmlString($"<label for='{targetId}'><span class='badge bg-success'>{labelText}<span></label>");
        }
    }
}