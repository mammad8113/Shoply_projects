using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using _01_framwork.Applicatin.TokenAuthorize;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _01_framwork.Infrastructure
{
    public class TokenFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManagement = (ITokenManagement)context.HttpContext.RequestServices.GetService(typeof(ITokenManagement));

            var result = true;
            if (!context.HttpContext.Response.Headers.ContainsKey("Authorization"))
                result = false;

            string token = string.Empty;
            if (result)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                if (!tokenManagement.VerifyToken(token))
                    result = false;
            }

            if (!result)
            {
                context.ModelState.AddModelError("Unathorized", "product key is not valid");
                context.Result = new UnauthorizedObjectResult(context.ModelState);

            }
        }
    }
}
