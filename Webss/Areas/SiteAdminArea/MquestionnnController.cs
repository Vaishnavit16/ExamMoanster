using Infras;
using Microsoft.AspNetCore.Mvc;
using Webss.CustAuth;

namespace Webss.Areas.SiteAdminArea
{
    [Area("SiteAdminArea")]
    [SiteAdminAuth]
    public class MquestionnnController : Controller
    {
        Context cc;
        public MquestionnnController(Context cc)
        {
            this.cc = cc;
        }

        public IActionResult Index()
        {
            return View(this.cc.mockTestQueOptions.ToList());
        }
    }
}
