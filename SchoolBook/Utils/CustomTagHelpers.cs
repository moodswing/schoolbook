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

    [HtmlTargetElement("spinner")]
    public class SpinnerHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Add("class", "spin-container");

            var sb = new StringBuilder();

            sb.AppendFormat("<div class='spinner'><div class='bounce1'></div><div class='bounce2'></div><div class='bounce3'></div></div>");

            output.Content.SetHtmlContent(sb.ToString());
        }
    }

    [HtmlTargetElement("confirm-action")]
    public class ConfirmActionHelper : TagHelper
    {
        [HtmlAttributeName("message")]
        public string Message { get; set; }

        [HtmlAttributeName("yes-title")]
        public string Yes { get; set; }

        [HtmlAttributeName("no-title")]
        public string No { get; set; }

        [HtmlAttributeName("callback")]
        public string Callback { get; set; }

        [HtmlAttributeName("display-over")]
        public string Position { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Add("class", "action-confirmation");
            output.Attributes.Add("style", "display: none;");

            var sb = new StringBuilder();

            sb.AppendFormat("<div class=title>{0}</div>", Message);
            sb.AppendFormat("<i class='flaticon-remove-symbol icon' style='display:none;' onclick=cancelConfirmation('{0}')></i>", Position);
            sb.AppendFormat("<button id=btnCancel class=btn-secondary onclick=cancelConfirmation('{1}')>{0}</button>", No, Position);
            sb.AppendFormat("<button id=btnOk class=btn-primary onclick='showConfirmationSpinner(this); {1}'>{0}</button>", Yes, Callback);
            sb.AppendFormat("<div class='spinner'><div class='bounce1'></div><div class='bounce2'></div><div class='bounce3'></div></div>");

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
