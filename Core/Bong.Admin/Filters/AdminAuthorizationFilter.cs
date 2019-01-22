using System;
using Bong.Security;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bong.Admin.Filters
{
    public class AdminAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IAuthenticationProvider _provider;

        public AdminAuthorizationFilter(IAuthenticationProvider provider)
        {
            _provider = provider;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.RouteValues.ContainsKey("controller") == false)
            {
                return;
            }

            if (context.ActionDescriptor.RouteValues["controller"]
                .Contains("Admin", StringComparison.InvariantCultureIgnoreCase) == false)
            {
                return;
            }

            var challengeResult = _provider.Challenge(context.HttpContext.Request).Result;
            if (challengeResult.IsAuthenticated == false)
            {
                context.Result = challengeResult.Action;
            }
        }
    }
}