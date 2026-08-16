using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Mvc7_TagHelpers.TagHelpers
{
    public class MailTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";   //Replace <email> with <a> tag
        }
    }
}
