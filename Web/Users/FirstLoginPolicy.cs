using Core.Users;
using Core.Users.UserRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Web.Configuration;

namespace Web.Users
{
    public static class FirstLoginPolicyExtensions
    {
        public static AuthorizationPolicyBuilder RequirePasswordChangeAfterFirstLogin(this AuthorizationPolicyBuilder builder)
        {
            builder.Requirements.Add(new FirstLoginPolicy());
            return builder;
        }
    }

    public class FirstLoginPolicy : AuthorizationHandler<FirstLoginPolicy>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FirstLoginPolicy requirement)
        {
            if (
                IsFirstLogin(context) &&
                !HasAllowOnFirstLoginAttribute(context)
            )
            {
                var authorizationFilterContext = context.Resource as AuthorizationFilterContext;
                authorizationFilterContext.Result = new JsonResult("Password change required") { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private bool HasAllowOnFirstLoginAttribute(AuthorizationHandlerContext context)
        {
            var mvcContext = context.Resource as AuthorizationFilterContext;
            var descriptor = mvcContext.ActionDescriptor as ControllerActionDescriptor;

            if (descriptor != null)
            {
                var attribute = descriptor
                    .MethodInfo
                    .GetCustomAttributes()
                    .OfType<AllowOnFirstLoginAttribute>()
                    .FirstOrDefault();

                if (attribute != null)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsFirstLogin(AuthorizationHandlerContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                string firstLoginClaim = context.User.GetClaim(CustomClaimTypes.FirstLogin);

                if (bool.TryParse(firstLoginClaim, out bool firstLogin) && firstLogin)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
