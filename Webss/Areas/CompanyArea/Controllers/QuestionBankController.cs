using Domain;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webss.CustAuth;

namespace Webss.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class QuestionBankController : Controller
    {
        IQuestionBank repo;
        IQuestionDBcategory questionDBcategory;
        Icompany companyy;
        public QuestionBankController(IQuestionBank repo, IQuestionDBcategory questionDBcategory, Icompany companyy)
        {
            this.repo = repo;
            this.questionDBcategory = questionDBcategory;
            this.companyy = companyy;
        }

        public async Task< IActionResult> Index()
        {
            return View(await this.repo.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.questiondbcategories = new SelectList(await this.questionDBcategory.GetAll(), "QuestionDBCategoryID", "QuestionDBCategoryName");
            ViewBag.companies = new SelectList(await this.companyy.GetAll(), "CompanyID", "CompanyName");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(QuestionBank rec)
        {
            ViewBag.questiondbcategories= new SelectList(await this.questionDBcategory.GetAll(), "QuestionDBCategoryID", "QuestionDBCategoryName");
            ViewBag.companies = new SelectList(await this.companyy.GetAll(), "CompanyID", "CompanyName");
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
            ViewBag.questiondbcategories = new SelectList(await this.questionDBcategory.GetAll(), "QuestionDBCategoryID", "QuestionDBCategoryName",rec.QuestionDBCategoryID);
            ViewBag.companies = new SelectList(await this.companyy.GetAll(), "CompanyID", "CompanyName",rec.CompanyID);
            return View(rec);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(QuestionBank rec)
        {
            ViewBag.questiondbcategories = new SelectList(await this.questionDBcategory.GetAll(), "QuestionDBCategoryID", "QuestionDBCategoryName",rec.QuestionDBCategoryID);
            ViewBag.companies = new SelectList(await this.companyy.GetAll(), "CompanyID", "CompanyName",rec.CompanyID);
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
