using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace HardwareManagement_.core_.TagHelpers
{
    public class OpenModal:TagHelper
    {
        public required string Url { get; set; }
        public string? Title { get; set; }

        public string Class { get; set; }= "btn btn-success";
    public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Attributes.Add("OnClick", $"OpenModal('{Url}','Default modal','{Title}')");
          
            output.Attributes.Add("class", Class);
            base.Process(context, output);
        }
    }
}
