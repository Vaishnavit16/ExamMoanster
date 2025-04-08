using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Webss.CustAuth
{
    public class CandidateAuth : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("CandidateID") == null)
            {
                context.Result = new RedirectToActionResult("SignIn", "CandidateManage", new { area = "" });
            }
        }
    }
}
