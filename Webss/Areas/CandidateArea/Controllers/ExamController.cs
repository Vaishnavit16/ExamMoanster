using Domain;
using Infras;
using Microsoft.AspNetCore.Mvc;
using Webss.CustAuth;

namespace Webss.Areas.CandidateArea
{
    [Area("CandidateArea")]
    [CandidateAuth]
    public class ExamController : Controller
    {
        Context cc;
        public ExamController(Context cc)
        {
            this.cc = cc;
        }
        public IActionResult Index()
        {
            Int64 id = Convert.ToInt64(HttpContext.Session.GetString("CandidateID"));
            var v = from t in cc.scheduleExams
                    join t1 in cc.scheduleExamCandidates
                    on t.ScheduleExamID equals t1.ScheduleExamID
                    where t1.CandidateID == id && !(from t2 in cc.ScheduleExamResults
                                                    join t3 in cc.scheduleExamCandidates
                                                    on t2.ScheduleExamCandidateID equals t3.ScheduleExamCandidateID
                                                    where t3.CandidateID == id
                                                    select t2.ScheduleExamCandidateID).Contains(t1.ScheduleExamCandidateID)
                    select t;

            return View(v.ToList());
        }


        [HttpGet]
        public IActionResult Start(Int64 id)
        {
            Int64 sid = Convert.ToInt64(HttpContext.Session.GetString("CandidateID"));
            var rec = cc.scheduleExams.Find(id);
            var v = (from t in cc.scheduleExamDets
                     where t.ScheduleExamID == id
                     select t).SingleOrDefault();
            ViewBag.id = (from t in cc.scheduleExamCandidates
                          where t.CandidateID == sid && t.ScheduleExamID == id
                          select t.ScheduleExamCandidateID).SingleOrDefault();
            return View(v);
        }

        [HttpGet]
        public IActionResult StartTest(Int64 id, Int64 data)
        {
            var v = cc.scheduleExamDets.Find(id);
            var bid = v.ScheduleExamID;
            var b = cc.scheduleExams.Find(bid);
            ViewBag.endtime = b.EndTime;
            Int64 qid = v.QuestionBankID;
            ViewBag.sid = id;
            ViewBag.aid = data;

            //var rec = cc.MockTestSubjects.FirstOrDefault(p => p.MockTestSubjectID == sid).MockTestQuestions.ToList();
            var rec = cc.questionBanks.FirstOrDefault(p => p.QuestionBankID == qid).Questions.ToList();

            return View(rec);
        }

       



        [HttpPost]
        public IActionResult Submit(List<Question> model, Int64 aid, Int64 sid)
        {
            Int64 s = 0;
            Int64 c = 0;
            var v = new ScheduleExamResult();
            v.ScheduleExamCandidateID = aid;
            v.ScheduleExamID = sid;

            foreach (var temp in model)
            {
                bool flag = true;
                Int64 no = 0;
                foreach (var temp1 in temp.QuestionAnswers)
                {
                    if (temp1.IsSelected == true)
                    {
                        if (temp1.IsCorrect == temp1.IsSelected)
                        {
                            // Correct answer, no action needed
                        }
                        else
                        {
                            flag = false; // Incorrect answer
                        }
                    }
                    else
                    {
                        no++; // No answer selected
                    }
                }

                if (flag == true)
                {
                    s++; // Correct answers count
                    c++; // Count of fully correct answers
                    if (no == 4) // If there are no answers selected for the question
                    {
                        s--; // Deduct for no answer
                        c--; // Deduct for no answer
                    }
                }
                else
                {
                    s++; // Incorrect answers still count towards the total answered questions
                }
            }

            var m = cc.scheduleExamDets.Find(v.ScheduleExamID);
            v.SolvedQuestions = s;
            Int64 cm = (c) * m.MarksPerQuestion;

            v.ObtainedMarks = cm;
            if (cm >= m.PassingMarks)
            {
                v.Result = ("Pass");
                ViewBag.ExamStatus = ("Pass");
            }
            else
            {
                v.Result = ("Fail");
                ViewBag.ExamStatus = ("Fail");
            }

            // Add the result to the database
            cc.ScheduleExamResults.Add(v);

            // Mark the exam as completed by setting its status to "Completed" (or other flag)
            var candidateExam = cc.scheduleExamCandidates.FirstOrDefault(x => x.ScheduleExamCandidateID == aid && x.ScheduleExamID == sid);
            

            cc.SaveChanges();

            // Redirect to the "Appair" tab to show the test results
            return RedirectToAction("Appair");
        }
        [Route("CandidateArea/Exam/[action]")]
        public IActionResult Appair()
        {
            return View();  // Render your "Appair" view here
        }
    }
}
            

            


    

