using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GroceryList.TagHelpers
{
    public class SecureHiddenTagHelper : TagHelper
    {

        public string Id { get; set; }
        public string Value { get; set; }
        public ModelExpression AspFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            base.Process(context, output);

            output.TagName = "input";
            output.Attributes.Add("type", "hidden");
            output.Attributes.Add("id", Id);
            output.Attributes.Add("value", Value);
            output.Attributes.Add("name", AspFor.Name);

            /*           var encryptedHidden = new TagBuilder("input");
                       encryptedHidden.Attributes.Add("type", "hidden");
                       encryptedHidden.Attributes.Add("id", Id);
                       encryptedHidden.Attributes.Add("value", Value);

                       output.PostElement.AppendHtml(encryptedHidden); */

        }

    }
}
