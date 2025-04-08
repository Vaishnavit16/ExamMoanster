using Infras;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Webss.CustAuth;

namespace Webss.Areas.CandidateArea.Controllers
{
    [Area("CandidateArea")]
    [CandidateAuth]
    public class examexamController : Controller
    {
        Context cc;
        public examexamController(Context cc)
        {
            this.cc = cc;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
