using _01_framwork.Applicatin;
using _01_framwork.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ServiceHost
{
    public class PageFilter : IPageFilter
    {
        private readonly IAuthHelper authHelper;

        public PageFilter(IAuthHelper authHelper)
        {
            this.authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {

        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerpermission = (NeddsPermissionAttribute)
                context.HandlerMethod.MethodInfo.GetCustomAttribute(typeof(NeddsPermissionAttribute));

            if (handlerpermission == null)
                return;

            var permissions = authHelper.GetPermissions();
            if (!permissions.Contains(handlerpermission.Permission))
                context.HttpContext.Response.Redirect("/AccessDenied");
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {

        }
    }
}
