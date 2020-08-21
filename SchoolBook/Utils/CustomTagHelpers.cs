using System.Text;
using SchoolBook.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SchoolBook.Utils
{
    [HtmlTargetElement("select-cascade")]
    public class DropDownListCascadeHelper : TagHelper
    {
        [HtmlAttributeName("list")]
        public IEnumerable<IListItem> SelectList { get; set; }

        [HtmlAttributeName("first-value")]
        public string FirstValue { get; set; }

        [HtmlAttributeName("selected")]
        public string Selected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Add("cascade", true);

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(FirstValue))
                sb.AppendFormat("<option>{0}</option>", FirstValue);

            foreach (IListItem item in SelectList)
                sb.AppendFormat("<option value={0} data-superior={1} {3}>{2}</option>", item.Value, item.SuperiorId, item.Text, Selected == item.Value ? "selected" : string.Empty);

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
