using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Webss.CustAuth;

namespace Webss.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class CompanyHomeController : Controller
    {
        Icompany repo;
        public CompanyHomeController(Icompany repo)
        {
            this.repo = repo;
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

                Int64 companyid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));

                var res = await this.repo.ChangePassword(rec, companyid);

                ViewBag.Message = res.Message;
                return View(rec);
            }
            return View(rec);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            Int64 companyid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var res = await this.repo.GetProfile(companyid);
            return View(res);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileDto rec)
        {
            if (ModelState.IsValid)
            {
                Int64 companyid = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
                var res = await this.repo.EditProfile(rec, companyid);
                ViewBag.Message = res.Message;
                return View(rec);
            }
            return View(rec);
        }


    }
}

