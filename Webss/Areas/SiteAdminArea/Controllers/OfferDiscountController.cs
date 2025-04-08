using Domain;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Webss.CustAuth;

namespace Webss.Areas.SiteAdminArea.Controllers
{
    [Area("SiteAdminArea")]
    [SiteAdminAuth]
    public class OfferDiscountController : Controller
    {
        IOfferDiscount repo;
        public OfferDiscountController(IOfferDiscount repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.repo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(OfferDiscount rec)
        {
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
            return View(rec);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(OfferDiscount rec)
        {
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
