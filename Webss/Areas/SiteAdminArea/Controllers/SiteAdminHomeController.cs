using Domain;
using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Webss.CustAuth;


namespace Webss.Areas.SiteAdminArea.Controllers
{
    [Area("SiteAdminArea")]
    [SiteAdminAuth]
    public class SiteAdminHomeController : Controller
    {
        Isiteadmin repo;
        public SiteAdminHomeController(Isiteadmin repo)
        {
            this.repo=repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto rec)
        {
            if (ModelState.IsValid)
            {

                Int64 siteadminid = Convert.ToInt64(HttpContext.Session.GetString("SiteAdminID"));

                var res = await this.repo.ChangePassword(rec,siteadminid);

                ViewBag.Message = res.Message;
                return View(rec);
            }
            return View(rec);
        }
    }
}
