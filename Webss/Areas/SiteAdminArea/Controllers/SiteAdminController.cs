using Infras;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Webss.CustAuth;

namespace Webss.Areas.SiteAdminArea.Controllers
{
    [Area("SiteAdminArea")]
    [SiteAdminAuth]
    public class SiteAdminController : Controller
    {    Context cc;
        Icompany icompany;
        public SiteAdminController(Icompany icompany,Context cc)
        {
            this.icompany = icompany;
            this.cc = cc;
        }
       
        public async Task<IActionResult> active()
        {   
            return View( await this.icompany.GetAll());  
        }
        public async Task<IActionResult> deactive()
        {
            return View(await this.icompany.GetAll());
        }

        public IActionResult activetoggle(Int64 id)
        {
            var company = this.cc.companies.Find(id);
            if( company!=null)
            {
                company.ActiveFlag=!company.ActiveFlag;
                this.cc.SaveChanges();
            }
            return RedirectToAction("deactive");
        }

        public IActionResult deactivetoggle(Int64 id)
        {
            var company = this.cc.companies.Find(id);
            if (company != null)
            {
                company.ActiveFlag = !company.ActiveFlag;
                this.cc.SaveChanges();
            }
            return RedirectToAction("active");
        }



    }
}
