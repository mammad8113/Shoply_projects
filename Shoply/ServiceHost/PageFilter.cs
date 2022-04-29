using _01_framwork.Applicatin;
using _01_framwork.Infrastructure;
using AcountManagement.Domain.Rol.Agg;
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
        private readonly IRolRepository rolRepository;
        public PageFilter(IAuthHelper authHelper, IRolRepository rolRepository)
        {
            this.authHelper = authHelper;
            this.rolRepository = rolRepository;
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
