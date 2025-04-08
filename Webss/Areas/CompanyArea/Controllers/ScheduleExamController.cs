using Domain;
using Infras;
using Infras.Dtos;
using Infras.Repository.Classes;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webss.CustAuth;

namespace Webss.Areas.CompanyArea.Controllers
{
    [Area("CompanyArea")]
    [CompanyAuth]
    public class ScheduleExamController : Controller
    {
        Context cc;
        IScdeule erepo;
        public ScheduleExamController(Context cc, IScdeule erepo)
        {
            this.cc = cc;
            this.erepo = erepo;

        }

          


        public async Task<IActionResult> Index()
        {
            var v = from t in cc.scheduleExams
                    join t1 in cc.scheduleExamDets on t.ScheduleExamID equals t1.ScheduleExamID
                    join company in cc.companies on t.CompanyID equals company.CompanyID
                    join package in cc.packagePurchases on t.PackagePurchaseID equals package.PackagePurchaseID
                    join questionBank in cc.questionBanks on t1.QuestionBankID equals questionBank.QuestionBankID
                    select new ScheduleExamVM
                    {
                        ScheduleExamID = t.ScheduleExamID,
                        ScheduleDate = t.ScheduleDate,
                        CompanyName = company.CompanyName, // Get Company name from the Company table
                        PackagePurchaseTitle = package.PackagePurchaseTitle, // Get Package Purchase title from the PackagePurchase table
                        ExamDate = t.ExamDate,
                        StartTime = t.StartTime,
                        EndTime = t.EndTime,
                        IsResultOpen = t.IsResultOpen,
                        IsObjective = t.IsObjective,
                        ScheduleExamDetID = t1.ScheduleExamDetID,
                        QuestionBankTitle = questionBank.QuestionBankTitle, // Get Question Bank title from the QuestionBank table
                        MarksPerQuestion = t1.MarksPerQuestion,
                        PassingMarks = t1.PassingMarks
                    };

            return View(v);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Int64 a = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var v = from t in cc.packagePurchases
                    where t.CompanyID == a
                    select new PackagePurchase
                    {
                        PackagePurchaseID = t.PackagePurchaseID,
                        PackagePurchaseTitle = t.PackagePurchaseTitle
                    };
       
            ViewBag.packagepurchaseid = new SelectList(cc.packagePurchases.ToList() ,"PackagePurchaseID", "PackagePurchaseTitle");
            ViewBag.questionbankid = new SelectList(cc.questionBanks.ToList(), "QuestionBankID", "QuestionBankTitle");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ScheduleExamVM rec)
        {
            Int64 a = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var v = from t in cc.packagePurchases
                    where t.CompanyID == a
                    select new PackagePurchase
                    {
                        PackagePurchaseID = t.PackagePurchaseID,
                        PackagePurchaseTitle = t.PackagePurchaseTitle
                    };
            ViewBag.packagepurchaseid = new SelectList(v.ToList(), "PackagePurchaseID", "PackagePurchaseTitle");
            ViewBag.questionbankid = new SelectList(cc.questionBanks.ToList(), "QuestionBankID", "QuestionBankTitle");
            if (rec != null)
            {
                var s = new ScheduleExam();
                s.CompanyID = a;
                s.ScheduleDate = rec.ScheduleDate;
                s.PackagePurchaseID = rec.PackagePurchaseID;
                s.ExamDate = rec.ExamDate;
                s.StartTime = rec.StartTime;
                s.EndTime = rec.EndTime;
                s.IsObjective = rec.IsObjective;
                s.IsResultOpen = rec.IsResultOpen;
                cc.scheduleExams.Add(s);
                cc.SaveChanges();

                var d = new ScheduleExamDet();
                d.ScheduleExamID = s.ScheduleExamID;
                d.QuestionBankID = rec.QuestionBankID;
                d.MarksPerQuestion = rec.MarksPerQuestion;
                d.PassingMarks = rec.PassingMarks;
                cc.scheduleExamDets.Add(d);
                cc.SaveChanges();
                return RedirectToAction("index");
            }
            return View(rec);
        }

        [HttpGet]
        public IActionResult AddCandidate(Int64 id)
        {

            var v = from t in cc.candidates
                    where !(from t1 in cc.scheduleExamCandidates
                            where t1.ScheduleExamID == id
                            select t1.CandidateID).Contains(t.CandidateID)
                    select t;



            ViewBag.id = id;
            return View(v.ToList());
        }
        [HttpGet]
        public IActionResult AssignExam(Int64 id, Int64 data)
        {
            var rec = new ScheduleExamCandidate();
            rec.CandidateID = id;
            rec.ScheduleExamID = data;
            this.cc.scheduleExamCandidates.Add(rec);
            this.cc.SaveChanges();
            return RedirectToAction("AddCandidate", new { id = data });
        }


        [HttpGet]
        public IActionResult Edit(Int64 id, Int64 data)
        {
            Int64 a = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var v = from t in cc.packagePurchases
                    where t.CompanyID == a
                    select new PackagePurchase
                    {
                        PackagePurchaseID = t.PackagePurchaseID,
                        PackagePurchaseTitle = t.PackagePurchaseTitle
                    };
            ViewBag.packagepurchaseid = new SelectList(cc.packagePurchases.ToList(), "PackagePurchaseID", "PackagePurchaseTitle");
            ViewBag.questionbankid = new SelectList(cc.questionBanks.ToList(), "QuestionBankID", "QuestionBankTitle");
            var s = cc.scheduleExams.Find(id);

            var rec = new ScheduleExamVM();
            rec.ScheduleExamID = id;
            rec.CompanyID = a;
            rec.ScheduleDate = s.ScheduleDate;
            rec.PackagePurchaseID = s.PackagePurchaseID;
            rec.ExamDate = s.ExamDate;
            rec.StartTime = s.StartTime;
            rec.EndTime = s.EndTime;
            rec.IsObjective = s.IsObjective;
            rec.IsResultOpen = s.IsResultOpen;

            var d = cc.scheduleExamDets.Find(data);
            rec.ScheduleExamDetID = data;
            rec.QuestionBankID = d.QuestionBankID;
            rec.MarksPerQuestion = d.MarksPerQuestion;
            rec.PassingMarks = d.PassingMarks;
            return View(rec);
        }
        [HttpPost]
        public IActionResult Edit(ScheduleExamVM rec)
        {
            Int64 a = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
            var v = from t in cc.packagePurchases
                    where t.CompanyID == a
                    select new PackagePurchase
                    {
                        PackagePurchaseID = t.PackagePurchaseID,
                        PackagePurchaseTitle = t.PackagePurchaseTitle
                    };
            ViewBag.packagepurchaseid = new SelectList(v.ToList(), "PackagePurchaseID", "PackagePurchaseTitle", rec.PackagePurchaseID);
            ViewBag.questionbankid = new SelectList(cc.questionBanks.ToList(), "QuestionBankID", "QuestionBankTitle", rec.QuestionBankID);
            if (rec != null)
            {
                var s = cc.scheduleExams.Find(rec.ScheduleExamID);
                s.CompanyID = a;
                s.ScheduleDate = rec.ScheduleDate;
                s.PackagePurchaseID = rec.PackagePurchaseID;
                s.ExamDate = rec.ExamDate;
                s.StartTime = rec.StartTime;
                s.EndTime = rec.EndTime;
                s.IsObjective = rec.IsObjective;
                s.IsResultOpen = rec.IsResultOpen;



                var d = cc.scheduleExamDets.Find(rec.ScheduleExamDetID);
                d.ScheduleExamDetID = rec.ScheduleExamDetID;
                d.QuestionBankID = rec.QuestionBankID;
                d.MarksPerQuestion = rec.MarksPerQuestion;
                d.PassingMarks = rec.PassingMarks;
                d.ScheduleExamID = s.ScheduleExamID;

                this.cc.SaveChanges();
                return RedirectToAction("index");
            }
            return View(rec);
        }
        [HttpGet]
        public IActionResult Delete(Int64 id, Int64 data)
        {
            var rec = this.cc.scheduleExamDets.Find(data);
            this.cc.scheduleExamDets.Remove(rec);

            var v = this.cc.scheduleExams.Find(id);
            this.cc.scheduleExams.Remove(v);
            this.cc.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task< IActionResult> Run(ScheduleExam rec)
        {
            var ss = await erepo.Running();
            var result = ss.Select(s => new
            {
                s.ScheduleExamID,
                s.ScheduleDate,
                s.Company.CompanyName,
                s.PackagePurchase.PackagePurchaseTitle,
                s.ExamDate,
                s.StartTime,
                s.EndTime,
                s.IsResultOpen,
                s.IsObjective
            }).ToList();
            return Json(result);
        }
        [HttpGet]

        public async Task<IActionResult> Finish(ScheduleExam rec)
        {
            var ss = await erepo.Finished();
            var result = ss.Select(s => new
            {
                s.ScheduleExamID,
                s.ScheduleDate,
                s.Company.CompanyName,
                s.PackagePurchase.PackagePurchaseTitle,
                s.ExamDate,
                s.StartTime,
                s.EndTime,
                s.IsResultOpen,
                s.IsObjective
            }).ToList();
            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var scheduleExam = await cc.scheduleExams
                .Include(se => se.Company)
                .Include(se => se.PackagePurchase)
                .Include(se => se.ScheduleExamCandidates)
                .Include(se => se.ScheduleExamDets)
                .ThenInclude(d => d.QuestionBank)
                .FirstOrDefaultAsync(se => se.ScheduleExamID == id);

            if (scheduleExam == null)
            {
                return NotFound();
            }

            return View(scheduleExam);
        }



    }
}
