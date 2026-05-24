using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace LibrarySystem.Helpers
{
    /// <summary>
    /// Custom authorization filter that checks if the request's HttpContext.User is authenticated,
    /// and optionally verifies whether the user is member of specified roles.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string[] _roles;

        /// <summary>
        /// Restricts access to users belonging to the specified roles.
        /// If no roles are provided, any authenticated user will be allowed access.
        /// Multiple roles can be specified as comma-separated values (e.g. "SuperAdmin,Staff").
        /// </summary>
        public CustomAuthorizeAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            // 1. Check if user is authenticated
            if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
            {
                // Redirect unauthorized guests to login page, preserving the return URL
                context.Result = new RedirectToActionResult("Login", "Auth", new { returnUrl = context.HttpContext.Request.Path });
                return;
            }

            // 2. Check if specific roles are required
            if (_roles != null && _roles.Length > 0)
            {
                bool isAuthorized = false;

                foreach (var requiredRole in _roles)
                {
                    // Split comma-separated roles in case they were passed as a single string (e.g., "SuperAdmin,Staff")
                    var requiredRolesSplit = requiredRole.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var r in requiredRolesSplit)
                    {
                        if (user.IsInRole(r.Trim()))
                        {
                            isAuthorized = true;
                            break;
                        }
                    }
                    if (isAuthorized) break;
                }

                // If authenticated but lacks the required roles, redirect to Access Denied
                if (!isAuthorized)
                {
                    context.Result = new RedirectToActionResult("AccessDenied", "Auth", null);
                }
            }
        }
    }
}
