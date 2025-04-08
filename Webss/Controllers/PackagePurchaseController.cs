using Microsoft.AspNetCore.Mvc;

namespace Webss.Controllers
{
    public class PackagePurchaseController : Controller
    {
        public IActionResult Buy()
        {
            return RedirectToAction("SignIn","CompanyManage",new {area=""});
        }
    }
}
