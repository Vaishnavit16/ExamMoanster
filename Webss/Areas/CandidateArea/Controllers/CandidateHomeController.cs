using Domain.Enums;
using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webss.CustAuth;

namespace Webss.Areas.CandidateArea.Controllers
{
    [Area("CandidateArea")]
    [CandidateAuth]
    public class CandidateHomeController : Controller
    {
        Icandidate repo;
        public CandidateHomeController(Icandidate repo)
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

                Int64 candidateid = Convert.ToInt64(HttpContext.Session.GetString("CandidateID"));

                var res = await this.repo.ChangePassword(rec, candidateid);

                ViewBag.Message = res.Message;
                return View(rec);
            }
            return View(rec);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var Gender = Enum.GetValues(typeof(GenderEnum)).Cast<GenderEnum>()
                .Select(c => new SelectListItem
                {
                    Value = ((int)c).ToString(),
                    Text = c.ToString()
                }).ToList();
            ViewBag.genders = Gender;

            Int64 candidateid = Convert.ToInt64(HttpContext.Session.GetString("CandidateID"));
            var res = await this.repo.GetProfile(candidateid);
            return View(res);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileDto rec)
        {
            if (ModelState.IsValid)
            {
                Int64 candidateid = Convert.ToInt64(HttpContext.Session.GetString("CandidateID"));
                var res = await this.repo.EditProfile(rec, candidateid);
                ViewBag.Message = res.Message;
                return View(rec);
            }
            return View(rec);
        }

    }
}
