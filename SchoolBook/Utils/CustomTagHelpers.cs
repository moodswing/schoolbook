using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

            var isRequired = context.AllAttributes.Any(a => a.Name.ToLower() == "required");

            foreach (IListItem item in SelectList)
            {
                sb.AppendFormat("<div class='options {0}'>", Selected == item.Value ? "selected" : string.Empty);
                sb.AppendFormat("<input id={0} type=radio value={1} name={2} {3} {4}>", Property + item.Value, item.Value, Property, Selected == item.Value ? "checked" : string.Empty, isRequired ? "required" : "");
                sb.AppendFormat("<label for={0}>{1}</label>", Property + item.Value, item.Text);
                sb.AppendFormat("</div>");
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }

    [HtmlTargetElement("checkbox")]
    public class CheckBoxHelper : TagHelper
    {
        [HtmlAttributeName("name")]
        public string Name { get; set; }

        [HtmlAttributeName("checked")]
        public bool Checked { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "checkbox";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();

            var id = Name.Replace(".", "_").Replace("[", "_").Replace("]", "_");

            sb.AppendFormat("<input id={0} type=checkbox {1} name={2} style='display: none;'>", id, Checked ? "checked" : "", Name);
            sb.AppendFormat("<i class='{0}'></i>", Checked ? "flaticon-check" : "flaticon-check-box-empty");

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

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Add("class", "action-confirmation");
            output.Attributes.Add("style", "display: none;");

            var sb = new StringBuilder();

            sb.AppendFormat("<div class=title>{0}</div>", Message);
            sb.AppendFormat("<i class='flaticon-remove-symbol icon' style='display:none;' onclick=cancelConfirmation(this)></i>");
            sb.AppendFormat("<button id=btnCancel type='button' class=btn-secondary onclick=cancelConfirmation(this)>{0}</button>", No);
            sb.AppendFormat("<button id=btnOk type='button' class=btn-primary onclick='showConfirmationSpinner(this); {1}'>{0}</button>", Yes, Callback.Replace("'", "\""));
            sb.AppendFormat("<div class='spinner'><div class='bounce1'></div><div class='bounce2'></div><div class='bounce3'></div></div>");

            output.Content.SetHtmlContent(sb.ToString());
        }
    }

    [HtmlTargetElement("autocomplete")]
    public class AutoCompleteHelper : TagHelper
    {
        [HtmlAttributeName("list")]
        public IEnumerable<IListItem> SelectList { get; set; }

        public ModelExpression For { get; set; }

        [HtmlAttributeName("max-items")]
        public string MaxItems { get; set; }

        [HtmlAttributeName("placeholder")]
        public string Placeholder { get; set; }

        [HtmlAttributeName("multiple-selection")]
        public bool MultipleSelection { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "autocomplete";
            output.TagMode = TagMode.StartTagAndEndTag;

            if (MultipleSelection)
                output.Attributes.Add("multiple-selection", "");

            var isRequired = context.AllAttributes.Any(a => a.Name.ToLower() == "required");
            if (isRequired)
                output.Attributes.Add("required", "");

            var sb = new StringBuilder();

            MaxItems ??= "5";

            var selected = For != null && For.Model != null ? SelectList.FirstOrDefault(i => i.Value == For.Model.ToString()) : null;
            var value = For != null && For.Model != null && !MultipleSelection ? For.Model : string.Empty;
            var name = For != null ? For.Name : string.Empty;

            sb.AppendFormat("<input type=text placeholder={0} class='form-control' data-max-items={1} {2} value='{3}' />", Placeholder, MaxItems, MultipleSelection ? "data-list-name='" + name + "'" : "" , selected != null ? selected.Text : "");
            sb.AppendFormat("<div class=underline></div>");
            sb.AppendFormat("<i class='flaticon-magnifying-glass small-icon'></i>");
            sb.AppendFormat("<div class='autocomplete-list'>");

            var addButton = "<i class='flaticon-add-square-button small-icon'></i>";

            foreach (IListItem item in SelectList)
                sb.AppendFormat("<div data-id={0}>{1}{2}</div>", item.Value, item.Text, MultipleSelection ? addButton : "");

            sb.AppendFormat("<div class='display-all' onclick='DisplayAllAutoComplete(this)'>Mostrar todos</div>");
            sb.AppendFormat("</div>");

            if (MultipleSelection)
                sb.AppendFormat("<div class='selection-list'></div>");
            else
                sb.AppendFormat("<input name={0} type=hidden value='{1}' />", name, value);

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
