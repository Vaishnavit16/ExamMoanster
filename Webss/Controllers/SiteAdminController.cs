using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Webss.Controllers
{
    public class SiteAdminController : Controller
    {
        Isiteadmin repo;
        public SiteAdminController(Isiteadmin repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(Logindto rec)
        {
            if (ModelState.IsValid)
            {
                var res = await this.repo.Login(rec);
                if (res.IsLoggedIn)
                {
                    HttpContext.Session.SetString("LoggedInName", res.LoggedInName);
                    HttpContext.Session.SetString("SiteAdminID", res.LoggedInID.ToString());
                    return RedirectToAction("Index", "SiteAdminHome", new { area = "SiteAdminArea" });
                }

                ModelState.AddModelError("", res.Messgae);
                return View(rec);
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return View();
        }

    }
}

