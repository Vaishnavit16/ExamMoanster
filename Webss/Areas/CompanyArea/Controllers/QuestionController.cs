using Domain;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webss.CustAuth;

namespace Webss.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class QuestionController : Controller
    {
        IQuestion repo;
        IQuestionBank bank;
        public QuestionController(IQuestion repo, IQuestionBank bank)
        {
            this.repo = repo;
            this.bank = bank;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.repo.GetAll());
        }

        [HttpGet]
        public async Task< ActionResult> Create()
        {
            ViewBag.questionbanks= new SelectList(await this.bank.GetAll(), "QuestionBankID", "QuestionBankTitle");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Question rec)
        {
            ViewBag.questionbanks = new SelectList(await this.bank.GetAll(), "QuestionBankID", "QuestionBankTitle");
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
            ViewBag.questionbanks = new SelectList(await this.bank.GetAll(), "QuestionBankID", "QuestionBankTitle",rec.QuestionBankID);
            return View(rec);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Question rec)
        {
            ViewBag.questionbanks = new SelectList(await this.bank.GetAll(), "QuestionBankID", "QuestionBankTitle",rec.QuestionBankID);
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
