using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Webss.Controllers
{
    public class CandidateManageController : Controller
    {
        Icandidate repo;
        public CandidateManageController(Icandidate repo)
        {
            this.repo = repo;
        }

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
                    HttpContext.Session.SetString("CandidateID", res.LoggedInID.ToString());
                    return RedirectToAction("Index", "CandidateHome", new { area = "CandidateArea" });
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
