using System.Text;
using SchoolBook.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

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

    [HtmlTargetElement("radiobutton")]
    public class RadioButtonHelper : TagHelper
    {
        [HtmlAttributeName("list")]
        public IEnumerable<IListItem> SelectList { get; set; }

        [HtmlAttributeName("for")]
        public string Property { get; set; }

        [HtmlAttributeName("selected")]
        public string Selected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "radiobutton";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();

            if (SelectList == null || !SelectList.Any()) return;

            foreach (IListItem item in SelectList)
            {
                sb.AppendFormat("<div class='options {0}'>", Selected == item.Value ? "selected" : string.Empty);
                sb.AppendFormat("<input id={0} type=radio value={1} name={2} {3}>", Property + item.Value, item.Value, Property, Selected == item.Value ? "checked" : string.Empty);
                sb.AppendFormat("<label for={0}>{1}</label>", Property + item.Value, item.Text);
                sb.AppendFormat("</div>");
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
