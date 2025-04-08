using Infras;
using Microsoft.AspNetCore.Mvc;
using Webss.CustAuth;

namespace Webss.Areas.CandidateArea.Controllers
{
    [Area("CandidateArea")]
    [CandidateAuth]
    public class testController : Controller
    {
        Context cc;
        public testController(Context cc)
        {
            this.cc = cc;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
