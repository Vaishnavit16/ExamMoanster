using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Webss.CustAuth
{
    public
        class CompanyAuth : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("CompanyID") == null)
            {
                context.Result = new RedirectToActionResult("SignIn", "CompanyManage", new { area = "" });
            }
        }
    }
}
