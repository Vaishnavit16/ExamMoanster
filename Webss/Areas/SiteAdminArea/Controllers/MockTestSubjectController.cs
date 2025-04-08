using Domain;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webss.CustAuth;

namespace Webss.Areas.SiteAdminArea.Controllers
{
    [Area("SiteAdminArea")]
    [SiteAdminAuth]
    public class MockTestSubjectController : Controller
    {
        IMockTestCategory mockTestCategory;
        ImockTestSubject repo;
        public MockTestSubjectController(ImockTestSubject repo, IMockTestCategory mockTestCategory)
        {
            this.mockTestCategory = mockTestCategory;
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.repo.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.MockTestCategoryyy = new SelectList(await this.mockTestCategory.GetAll(), "MockTestCategoryID", "MockTestCategoryName");

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(MockTestSubject rec)
        {
            ViewBag.MockTestCategoryyy = new SelectList(await this.mockTestCategory.GetAll(), "MockTestCategoryID", "MockTestCategoryName");

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
            ViewBag.MockTestCategoryyy = new SelectList(await this.mockTestCategory.GetAll(), "MockTestCategoryID", "MockTestCategoryName", rec.MockTestCategoryID);

            return View(rec);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(MockTestSubject rec)
        {
            ViewBag.MockTestCategoryyy = new SelectList(await this.mockTestCategory.GetAll(), "MockTestCategoryID", "MockTestCategoryName", rec.MockTestCategoryID);

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
