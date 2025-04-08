//using Infras;
//using Microsoft.AspNetCore.Mvc;

//namespace Webss.ViewComponents
//{
//    public class AppairVC : ViewComponent
//    {
//        Context cc;
//        public AppairVC(Context cc)
//        {
//            this.cc = cc;
//        }

//        public IViewComponentResult Invoke()
//        {
//            if (!long.TryParse(HttpContext.Session.GetString("CandidateID"), out long candid))
//            {
//                return Content("Candidate not found in session.");
//            }


//            var candidatePerformances = cc.scheduleExams
//                .Where(cp => cp.ScheduleExamID == candid)
//                .ToList();

//            if (!candidatePerformances.Any())
//            {
//                return Content("No performance records found.");
//            }


//            var attemptedMockTestIds = candidatePerformances.Select(cp => cp.ScheduleExamID).Distinct().ToList();


//            var attemptedMockTests = cc.scheduleExams
//                .Where(mt => attemptedMockTestIds.Contains(mt.ScheduleExamID))
//                .ToList();

//            return View("Default", attemptedMockTests);
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Domain;
using System.Threading.Tasks;
using Infras.Repository.Interface;
using Infras;

public class ExamController : Controller
{
    private readonly IScdeule _repo;
    private readonly Context _cc;

    public ExamController(IScdeule repo, Context cc)
    {
        _repo = repo;
        _cc = cc;
    }

    [HttpPost]
    public async Task<IActionResult> Appear(int id)
    {
        // Logic to get the exam details and start the exam
        var exam = await _repo.Get(id); // Get the exam details from the repository

        if (exam == null)
        {
            return NotFound();
        }

        // Add any logic needed to initialize the exam session, such as updating status or starting timers

        return RedirectToAction("TakeExam", new { examId = exam.ScheduleExamID });
    }

    // Action to handle the actual exam taking page
    public IActionResult TakeExam(int examId)
    {
        // Logic to handle the exam taking page
        var examDetails = _repo.Get(examId);
        return View(examDetails);
    }
}

