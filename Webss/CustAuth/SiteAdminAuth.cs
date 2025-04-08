using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Webss.CustAuth;

public class SiteAdminAuth : ActionFilterAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.Session.GetString("SiteAdminID") == null)
        {
            context.Result = new RedirectToActionResult("SignIn", "SiteAdmin", new { area = "" });
        }
        
    }
}

