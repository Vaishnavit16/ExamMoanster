using Domain;
using Infras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webss.CustAuth;

namespace Webss.Areas.CandidateArea.Controllers
{
    [Area("CandidateArea")]
    [CandidateAuth]
    public class MocktestController : Controller
    {
        Context cc;
        public MocktestController(Context cc)
        {
            this.cc = cc;
        }

       
        
            public IActionResult Index()
            {
                ViewBag.mocktestsubject = new SelectList(cc.mockTestSubjects.ToList(), "MockTestSubjectID", "SubjectTitle");
                return View(cc.mockTests.ToList());
            }


        [HttpGet]
        public IActionResult Start(Int64 id)
        {

            MockTest v = (from t in cc.mockTests
                          where t.MockTestID == id
                          select t).SingleOrDefault();
            return View(v);
        }

        [HttpGet]
        public IActionResult StartTest(Int64 id)
        {
            var v = cc.mockTests.Find(id);
            ViewBag.id = id;
            Int64 sid = v.MockTestSubjectID;
            var rec = cc.mockTestSubjects.FirstOrDefault(p => p.MockTestSubjectID == sid).MockTestQuestions.ToList();

            return View(rec);
        }

        [HttpPost]
        public IActionResult Submit(List<MockTestQuestion> model)
        {
            Int64 s = 0;
            Int64 c = 0;
            var v = new CandidatePerformance();
            v.CandidateID = Convert.ToInt64(HttpContext.Session.GetString("CandidateID"));
            foreach (var temp in model)
            {
                v.MockTestID = temp.MockTestID;

                bool flag = true;
                Int64 no = 0;
                foreach (var temp1 in temp.MockTestQueOptions)
                {
                    if (temp1.Selected == true)
                    {
                        if (temp1.IsCurrect == temp1.Selected)
                        {

                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        no++;
                    }

                }
                if (flag == true)
                {
                    s++;
                    c++;
                    if (no == 4)
                    {
                        s--;
                        c--;
                    }
                }
                else
                {
                    s++;
                }
            }
            cc.candidatesPerformance.Add(v);
            cc.SaveChanges();

            var m = cc.mockTests.Find(v.MockTestID);

            var rec = new CandidatePerformanceDet();
            rec.CandidatePerformanceID = v.CandidatePerformanceID;
            rec.MockTestID = v.MockTestID;
            rec.SolvedQuestion = s;
            Int64 cm = (c) * m.MarksPerQuestion;
            if (m.IsNegavtive == true)
            {
                var n = s - c;
                cm = cm - n;
            }

            rec.ObtainedMarks = cm;
            if (cm >= m.PassingMarks)
            {
                ViewBag.ExamStatus = ("Pass");
            }
            else
            {
                ViewBag.ExamStatus = ("Fail");
            }

            cc.candidatePerformanceDets.Add(rec);
            cc.SaveChanges();
            return View(rec);
        }






        //[HttpPost]
        //public IActionResult SubmitTest(List<MockTestQuestion> model)
        //{
        //    Int64 solvedQuestions = 0;
        //    Int64 correctAnswers = 0;
        //    var v = new CandidatePerformance();

        //    // Get CandidateID from session
        //    v.CandidateID = Convert.ToInt64(HttpContext.Session.GetString("CandidateID"));

        //    // Assuming MockTestID comes from somewhere (like a hidden field or parameter)
        //    Int64 mockTestID = 1;  // This should be passed from the view, here it's hardcoded for now
        //    v.MockTestID = mockTestID;

        //    // Ensure MockTest exists in the database before proceeding
        //    var mockTest = cc.mockTests.Find(mockTestID);
        //    if (mockTest == null)
        //    {
        //        // Handle the case when MockTest doesn't exist
        //        return RedirectToAction("Error", new { message = "MockTest not found." });
        //    }

        //    // Iterate through each question in the test
        //    foreach (var question in model)
        //    {
        //        // Ensure you have a selected answer for this question
        //        Int64 selectedAnswer = 0;
        //        bool flag = true;  // Flag to indicate if the question was solved

        //        foreach (var option in question.MockTestQuestionOptions)
        //        {
        //            // Assuming you're determining which option was selected from the model or form submission
        //            // This could be done by checking the selected option here (e.g. selectedAnswer = optionID)
        //            // For simplicity, let's assume the selected option is captured by selectedAnswer
        //        }

        //        if (flag == true)
        //        {
        //            solvedQuestions++;  // Increment for a solved question
        //            correctAnswers++;   // Assuming correct answer was selected (this can be changed based on logic)
        //            if (selectedAnswer == 4)  // Assuming 4 is an invalid or default option, adjust as needed
        //            {
        //                solvedQuestions--;
        //                correctAnswers--;
        //            }
        //        }
        //        else
        //        {
        //            solvedQuestions++;  // Increment even if the answer was not correct (answered question)
        //        }
        //    }

        //    // Add the CandidatePerformance record to the database
        //    cc.candidatesPerformance.Add(v);
        //    cc.SaveChanges();

        //    // Retrieve the MockTest details for calculations
        //    var m = cc.mockTests.Find(v.MockTestID);

        //    // Create and save CandidatePerformanceDet record
        //    var rec = new CandidatePerformanceDet
        //    {
        //        CandidatePerformanceID = v.CandidatePerformanceID,
        //        MockTestID = v.MockTestID,
        //        SolvedQuestion = solvedQuestions
        //    };

        //    // Calculate obtained marks
        //    Int64 obtainedMarks = correctAnswers * m.MarksPerQuestion;
        //    if (m.IsNegavtive)  // If negative marking applies
        //    {
        //        var negativeMarks = solvedQuestions - correctAnswers;
        //        obtainedMarks -= negativeMarks;
        //    }

        //    rec.ObtainedMarks = obtainedMarks;

        //    // Save the performance details
        //    cc.candidatePerformanceDets.Add(rec);
        //    cc.SaveChanges();

        //    return View();
        //}

    }
}
