using _01_framwork.Applicatin;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace ServiceHost
{
    [HtmlTargetElement(Attributes = "permission")]
    public class PermissionTagHelper : TagHelper
    {
        public int permission { get; set; }
        private readonly IAuthHelper authHelper;

        public PermissionTagHelper(IAuthHelper authHelper)
        {
            this.authHelper = authHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var permissions = authHelper.GetPermissions();
            if (!authHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }

            if (!permissions.Contains(permission))
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }
    }
}
