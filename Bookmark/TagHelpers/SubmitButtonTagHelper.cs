using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bookmark.TagHelpers
{
    [HtmlTargetElement(Attributes = "[type=submit]")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            output.Attributes.AppendCssBook("btn btn-dark");
        }
    }
}


