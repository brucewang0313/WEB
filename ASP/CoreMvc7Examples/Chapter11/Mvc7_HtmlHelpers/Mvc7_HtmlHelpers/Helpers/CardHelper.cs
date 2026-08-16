using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;


namespace Mvc7_HtmlHelpers.Helpers
{
    public static class CardHelper
    {
        public static IHtmlContent Card(this IHtmlHelper helper, string id, string url, string alternateText)
        {
            return Card(helper, id, url, alternateText, null);
        }

        public static IHtmlContent Card(this IHtmlHelper helper, string id, string url, string alternateText, object htmlAttributes)
        {
            //建立TagBuilder
            var builder = new TagBuilder("img");

            //建立id
            builder.GenerateId(id, "_");

            //加入attributes屬性
            builder.MergeAttribute("src", url);
            builder.Attributes.Add("alt", alternateText);

            //解析RouteValue然後加入attributes屬性
            var Attributes = new RouteValueDictionary(htmlAttributes);
            builder.MergeAttributes(new RouteValueDictionary(Attributes));

            return builder;
        }
    }
}