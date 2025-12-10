using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationMVC.Filters
{
    public class CustomAuthorizationFilter:Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // If user is NOT logged in
            if (!context.HttpContext.User.Identity!.IsAuthenticated)
            {
                // Redirect to Login page
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
