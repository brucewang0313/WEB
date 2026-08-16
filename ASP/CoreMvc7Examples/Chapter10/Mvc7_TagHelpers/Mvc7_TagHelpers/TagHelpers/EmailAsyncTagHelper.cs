using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Mvc7_TagHelpers.TagHelpers
{
    public class EmailAsyncTagHelper: TagHelper
    {
        public const string DomainName = "codemagic.com.tw";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";  //Replace <email> with <a> tag
            //取得TagHelperContent物件
            var taghelperContent = await output.GetChildContentAsync();
            //GetContent()方法會從TagHelperContent取得innerText字串值
            var recipient = taghelperContent.GetContent() + "@" + DomainName;
            //設定<a href="mailto:support_handler@codemagic.com.tw">
            output.Attributes.SetAttribute("href", "mailto:" + recipient);
            //設定element中的innerText
            output.Content.SetContent(recipient);
        }
    }
}
