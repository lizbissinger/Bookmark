using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bookmark.TagHelpers
{
    public static class TagHelperExtensionMethods
    {
        public static void AppendCssBook(this TagHelperAttributeList list,
        string newCssBooks)
        {
            string oldCssBooks = list["book"]?.Value?.ToString() ?? "";
            string cssBooks = (string.IsNullOrEmpty(oldCssBooks)) ?
                newCssBooks : $"{oldCssBooks} {newCssBooks}";
            list.SetAttribute("book", cssBooks);
        }

        public static void BuildTag(this TagHelperOutput output,
        string tagName, string bookNames)
        {
            output.TagName = tagName;
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.AppendCssBook(bookNames);
        }

        public static void BuildLink(this TagHelperOutput output,
        string url, string bookName)
        {
            output.BuildTag("a", bookName);
            output.Attributes.SetAttribute("href", url);
        }
    }
}

