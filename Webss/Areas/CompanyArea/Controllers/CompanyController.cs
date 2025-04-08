using Domain;
using Infras;
using Infras.Dtos;
using Infras.Repository.Classes;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using Webss.CustAuth;


namespace Webss.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class CompanyController : Controller
    {

        Icompany repo;
        IQuestionBank QuestionBank;
        IQuestion questions;
        Context cc;

        public CompanyController(IQuestionBank questionBank, IQuestion questions, Context cc, Icompany repo)
        {
            QuestionBank = questionBank;
            this.questions = questions;
            this.cc = cc;
            this.repo = repo;





        }

        public async Task<IActionResult> Index()
        {


            var questionBanks = await cc.questionBanks.ToListAsync();
            return View(questionBanks);

        }

        public async Task<IActionResult> ManageQuestions(int questionBankId)
        {
            //ViewBag.QuestionBankID = questionBankId;
            var questions = await cc.questions
                .Where(q => q.QuestionBankID == questionBankId)
                .ToListAsync();

            if (!questions.Any())
            {
                TempData["Message"] = "No questions found for this QuestionBank.";
            }

        
            var viewModel = new ManageQuestionsViewModel
            {
                QuestionBankId = questionBankId,
                Questions = questions
            };

            return View(viewModel);
        }


        

        public IActionResult Create(int questionBankId)
        {
            ViewBag.QuestionBank = questionBankId;
            return View();
        }




        


        [HttpPost]
        public async Task<IActionResult> Create(QuestionWithOptionsViewModelDTO rec)
        {
            ViewBag.QuestionBank = rec.QuestionBankID;

            
            if (rec.Option == null || rec.IsCorrect == null || rec.Option.Count != rec.IsCorrect.Count)
            {
                ModelState.AddModelError("", "Options and correct answer selections are not matching.");
                return View(rec);
            }

            if (ModelState.IsValid)
            {
               
                var result = await this.questions.AddQuestionWithOptionsAsync(rec);

              
                return RedirectToAction("ManageQuestions", new { questionBankId = rec.QuestionBankID });
            }

            return View(rec);
        }





        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(Int64 questionId, Int64 questionBankId)
        {
            var question = await cc.questions.FindAsync(questionId);
            

            
            var questionAnswers = await cc.questionAnswers.Where(qa => qa.QuestionID == questionId).ToListAsync();
            if (questionAnswers.Any())
            {
                cc.questionAnswers.RemoveRange(questionAnswers);
            }

    
            cc.questions.Remove(question);
            await cc.SaveChangesAsync();

            TempData["Message"] = "Question deleted successfully.";
            return RedirectToAction("ManageQuestions", new { questionBankId });
        }




        public async Task<IActionResult> QuestionDetail(Int64 questionId)
        {
           
            var question = await cc.questions
                .Where(q => q.QuestionID == questionId)
                .FirstOrDefaultAsync();

            var answers = await cc.questionAnswers
                .Where(qa => qa.QuestionID == questionId)
                .ToListAsync();

          
            var model = new QuestionsDetailDTO
            {
                QuestionTitle = question.QuestionTitle,
                IsObjective = question.IsObjective,
                Answers = answers.Select(a => new AnserDetailDTO
                {
                    Option = a.Option,
                    IsCorrect = a.IsCorrect
                }).ToList()
            };

           
            return View(model);
        }


        //[HttpGet]
        //public async Task<IActionResult> Edit(Int64 id)
        //{


        //    var question = await cc.questions
        //                             .Include(p => p.QuestionAnswers)
        //                             .FirstOrDefaultAsync(p => p.QuestionID == id);

        //    if (question == null)
        //    {
        //        return NotFound();
        //    }


        //    var model = new QuestionWithOptionsViewModelDTO
        //    {
        //        QuestionID = question.QuestionID,
        //        QuestionTitle = question.QuestionTitle,
        //        IsObjective = question.IsObjective,
        //        QuestionBankID = question.QuestionBankID,
        //        Option = question.QuestionAnswers.Select(qa => qa.Option).ToList(),
        //        IsCorrect = question.QuestionAnswers.Select(qa => qa.IsCorrect).ToList()
        //    };
        //    return View(model);



        //}



        [HttpGet]
        public async Task<IActionResult> Edit(Int64 id)
        {
            var question = await cc.questions
                                     .Include(p => p.QuestionAnswers)
                                     .FirstOrDefaultAsync(p => p.QuestionID == id);

            if (question == null)
            {
                return NotFound();
            }

            // Ensure that QuestionAnswers is not null or empty, and both Option and IsCorrect have matching counts
            var questionAnswers = question.QuestionAnswers;

            var optionList = questionAnswers.Select(qa => qa.Option).ToList();
            var isCorrectList = questionAnswers.Select(qa => qa.IsCorrect).ToList();

            if (optionList.Count != isCorrectList.Count)
            {
                // If there's a mismatch, handle it (for example, log or show an error)
                ModelState.AddModelError("", "Mismatch between options and correctness flags.");
                return View("Error"); // or any appropriate view to show the error
            }

            var model = new QuestionWithOptionsViewModelDTO
            {
                QuestionID = question.QuestionID,
                QuestionTitle = question.QuestionTitle,
                IsObjective = question.IsObjective,
                QuestionBankID = question.QuestionBankID,
                Option = optionList,
                IsCorrect = isCorrectList
            };

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(QuestionWithOptionsViewModelDTO rec)
        {

            if (!ModelState.IsValid)
            {

                return View(rec);
            }




            var res = await cc.questions.Include(p => p.QuestionAnswers)
                                          .FirstOrDefaultAsync(p => p.QuestionID == rec.QuestionID);




            if (rec.QuestionBankID == 0)
            {
                ModelState.AddModelError("QuestionBankID", "Invalid Question Bank ID.");
                return View(rec);
            }


            res.QuestionTitle = rec.QuestionTitle;
            res.IsObjective = rec.IsObjective;



            cc.questionAnswers.RemoveRange(res.QuestionAnswers);


            var answers = new List<QuestionAnswer>();
            for (int i = 0; i < rec.Option.Count; i++)
            {
                var isCorrect = rec.IsCorrect[i];

                var answer = new QuestionAnswer
                {
                    Option = rec.Option[i],
                    IsCorrect = isCorrect,
                    QuestionID = res.QuestionID
                };

                answers.Add(answer);
            }


            await cc.questionAnswers.AddRangeAsync(answers);


            cc.Entry(res).State = EntityState.Modified;


            await cc.SaveChangesAsync();


            return RedirectToAction("ManageQuestions", new { questionBankId = rec.QuestionBankID });
        }


    }




}









