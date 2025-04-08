using Domain;
using Infras;
using Infras.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webss.CustAuth;

namespace Webss.Areas.SiteAdminArea.Controllers
{
    [Area("SiteAdminArea")]
    [SiteAdminAuth]
    public class QuestionssController : Controller
    {
        Context cc;
        public QuestionssController(Context cc)
        {
            this.cc = cc;
        }

        public IActionResult Index()
        {
            return View(this.cc.mockTestQuestions.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.mocktestsubject = new SelectList(cc.mockTestSubjects.ToList(), "MockTestSubjectID", "SubjectTitle");
            return View();
        }

        [HttpPost]
        public IActionResult Create(QuestionAnswerVM rec)
        {
            ViewBag.mocktestsubject = new SelectList(cc.mockTestSubjects.ToList(), "MockTestSubjectID", "SubjectTitle");
            if (rec != null)
            {
                var a = new MockTestQuestion();
                a.MockTestSubjectID = rec.MockTestSubjectID;
                a.Questions = rec.Question;
                this.cc.mockTestQuestions.Add(a);
                this.cc.SaveChanges();

                var b = new MockTestQueOption();
                b.MockTestQuestionID = a.MockTestQuestionID;
                b.Option = rec.Option1;
                b.IsCurrect = rec.IsCurrect1;
                this.cc.mockTestQueOptions.Add(b);

                var c = new MockTestQueOption();
                c.MockTestQuestionID = a.MockTestQuestionID;
                c.Option = rec.Option2;
                c.IsCurrect = rec.IsCurrect2;
                this.cc.mockTestQueOptions.Add(c);

                var d = new MockTestQueOption();
                d.MockTestQuestionID = a.MockTestQuestionID;
                d.Option = rec.Option3;
                d.IsCurrect = rec.IsCurrect3;
                this.cc.mockTestQueOptions.Add(d);

                var e = new MockTestQueOption();
                e.MockTestQuestionID = a.MockTestQuestionID;
                e.Option = rec.Option4;
                e.IsCurrect = rec.IsCurrect4;
                this.cc.mockTestQueOptions.Add(e);

                this.cc.SaveChanges();

                return RedirectToAction("index");
            }

            return View(rec);
        }


        [HttpGet]
        public IActionResult Edit(Int64 id)
        {


            var rec = cc.mockTestQuestions.Find(id);
            ViewBag.mocktestsubject = new SelectList(cc.mockTestSubjects.ToList(), "MockTestSubjectID", "SubjectTitle", rec.MockTestSubjectID);
            if (rec != null)
            {
                var v = new QuestionAnswerVM();
                v.MockTestQuestionID = rec.MockTestQuestionID;
                v.Question = rec.Questions;

                var a = from t in cc.mockTestQueOptions
                        where t.MockTestQuestionID == rec.MockTestQuestionID
                        select t;
                List<string> lst = new List<string>();
                List<bool> bst = new List<bool>();
                List<Int64> ids = new List<Int64>();
                foreach (var temp in a)
                {
                    lst.Add(temp.Option);
                    bst.Add(temp.IsCurrect);
                    ids.Add(temp.MocktestQueOptionID);
                }
                v.Option1 = lst[0];
                v.Option2 = lst[1];
                v.Option3 = lst[2];
                v.Option4 = lst[3];

                v.IsCurrect1 = bst[0];
                v.IsCurrect2 = bst[1];
                v.IsCurrect3 = bst[2];
                v.IsCurrect4 = bst[3];

                v.MockTestQueOptionID1 = ids[0];
                v.MockTestQueOptionID2 = ids[1];
                v.MockTestQueOptionID3 = ids[2];
                v.MockTestQueOptionID4 = ids[3];
                return View(v);

            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(QuestionAnswerVM rec)
        {
            ViewBag.mocktestsubject = new SelectList(cc.mockTestSubjects.ToList(), "MockTestSubjectID", "SubjectTitle", rec.MockTestSubjectID);
            if (rec != null)
            {
                var v = new MockTestQuestion();
                v.MockTestSubjectID = rec.MockTestSubjectID;
                v.Questions = rec.Question;
                v.MockTestQuestionID = rec.MockTestQuestionID;
                cc.Entry(v).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                cc.SaveChanges();

                var a = new MockTestQueOption();
                a.MocktestQueOptionID = rec.MockTestQueOptionID1;
                a.MockTestQuestionID = v.MockTestQuestionID;
                a.Option = rec.Option1;
                a.IsCurrect = rec.IsCurrect1;
                cc.Entry(a).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                cc.SaveChanges();


                var b = new MockTestQueOption();
                b.MocktestQueOptionID = rec.MockTestQueOptionID2;
                b.MockTestQuestionID = rec.MockTestQuestionID;
                b.Option = rec.Option2;
                b.IsCurrect = rec.IsCurrect2;

                cc.Entry(b).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                cc.SaveChanges();

                var c = new MockTestQueOption();
                c.MocktestQueOptionID = rec.MockTestQueOptionID3;
                c.MockTestQuestionID = v.MockTestQuestionID;
                c.Option = rec.Option3;
                c.IsCurrect = rec.IsCurrect3;
                cc.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                cc.SaveChanges();


                var d = new MockTestQueOption();
                d.MocktestQueOptionID = rec.MockTestQueOptionID4;
                d.MockTestQuestionID = rec.MockTestQuestionID;
                d.Option = rec.Option4;
                d.IsCurrect = rec.IsCurrect4;
                cc.Entry(d).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                cc.SaveChanges();

                cc.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(Int64 id)
        {
            var v = new QuestionAnswerVM();
            var a = from t in cc.mockTestQueOptions
                    where t.MockTestQuestionID == id
                    select t;
            foreach (var temp in a)
            {
                var b = this.cc.mockTestQueOptions.Find(temp.MocktestQueOptionID);
                this.cc.Remove(b);
            }


            var d = this.cc.mockTestQuestions.Find(id);
            this.cc.Remove(d);
            cc.SaveChanges();
            return RedirectToAction("index");
        }


    

           public async Task<IActionResult> Details(long id)
        {
            // Retrieve the question details
            var question = await cc.mockTestQuestions
                .FirstOrDefaultAsync(q => q.MockTestQuestionID == id);

            if (question == null)
            {
                return NotFound(); // If no question is found, return a 404 error
            }

            // Retrieve all options for this question
            var options = await cc.mockTestQueOptions
                .Where(o => o.MockTestQuestionID == id)
                .ToListAsync();

            // Ensure that we have at least 4 options (Option1 to Option4)
            var model = new QuestionAnswerVM
            {
                MockTestQuestionID = question.MockTestQuestionID,
                Question = question.Questions,
            };

            // Dynamically assign options and their correctness
            if (options.Count >= 1)
            {
                model.Option1 = options[0].Option;
                model.IsCurrect1 = options[0].IsCurrect;
            }
            if (options.Count >= 2)
            {
                model.Option2 = options[1].Option;
                model.IsCurrect2 = options[1].IsCurrect;
            }
            if (options.Count >= 3)
            {
                model.Option3 = options[2].Option;
                model.IsCurrect3 = options[2].IsCurrect;
            }
            if (options.Count >= 4)
            {
                model.Option4 = options[3].Option;
                model.IsCurrect4 = options[3].IsCurrect;
            }

            // Return the model to the view
            return View(model);
        }

    }
}




