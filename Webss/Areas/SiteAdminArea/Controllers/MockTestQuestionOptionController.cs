using Domain;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webss.CustAuth;

namespace Webss.Areas.SiteAdminArea.Controllers
{
    [Area("SiteAdminArea")]
    [SiteAdminAuth]
    public class MockTestQuestionOptionController : Controller
    {
        IMockQuestionOption repo;
        IMockTestQuestion repoo;
        public MockTestQuestionOptionController(IMockQuestionOption repo, IMockTestQuestion repoo)
        {
            this.repo = repo;
            this.repoo = repoo;
        }

         public async Task< IActionResult> Index()
        {
            return View(await this.repo.GetAll());
        }




        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.Mquestion = new SelectList(await this.repoo.GetAll(), "MockTestQuestionID", "Questions");

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(MockTestQueOption rec)
        {
            ViewBag.Mquestion = new SelectList(await this.repoo.GetAll(), "MockTestQuestionID", "Questions");

            if (ModelState.IsValid)
            {
                await this.repo.Create(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Int64 id)
        {
            var rec = await this.repo.Get(id);
            ViewBag.Mquestion = new SelectList(await this.repoo.GetAll(), "MockTestQuestionID", "Questions",rec.MockTestQuestionID);

            return View(rec);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(MockTestQueOption rec)
        {
            ViewBag.Mquestion = new SelectList(await this.repoo.GetAll(), "MockTestQuestionID", "Questions", rec.MockTestQuestionID);

            if (ModelState.IsValid)
            {

                await this.repo.Update(rec);
                return RedirectToAction("Index");
            }
            return View(rec);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Int64 id)
        {
            await this.repo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
