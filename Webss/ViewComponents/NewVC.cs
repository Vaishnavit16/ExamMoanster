//using Domain;
//using Infras;
//using Infras.Repository.Interface;
//using Microsoft.AspNetCore.Mvc;

//namespace Webss.ViewComponents
//{
//    public class NewVC : ViewComponent
//    {
//        IScdeule repo;
//        Context cc;

//        public NewVC(IScdeule repo, Context cc)
//        {
//            this.repo = repo;
//            this.cc = cc;
//        }
//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            if (!long.TryParse(HttpContext.Session.GetString("CandidateID"), out long candid))
//            {
//                return Content("Candidate not found in session.");
//            }

//            var getallschedules = await repo.GetAll();

//            var attemptedschule = this.cc.candidatesPerformance
//                .Where(cp => cp.CandidateID == candid)
//                .Select(cp => cp.MockTestID)
//                .Distinct()
//                .ToList();

//            var unattemptedMockTests = getallschedules
//                .Where(mt => !attemptedschule.Contains(mt.ScheduleExamID))
//                .ToList();

//            return View("Default", unattemptedMockTests);
//        }

//    }
//}

using Domain;
using Infras;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Webss.ViewComponents
{
    public class NewVC : ViewComponent
    {
        IScdeule repo;
        Context cc;

        public NewVC(IScdeule repo, Context cc)
        {
            this.repo = repo;
            this.cc = cc;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Get the candidate ID from session
            if (!long.TryParse(HttpContext.Session.GetString("CandidateID"), out long candid))
            {
                return Content("Candidate not found in session.");
            }

            // Get all the scheduled exams
            var getallschedules = await repo.GetAll();

            // Get the mock tests the candidate has already attempted
            var attemptedschule = this.cc.candidatesPerformance
                .Where(cp => cp.CandidateID == candid)
                .Select(cp => cp.MockTestID)
                .Distinct()
                .ToList();

            // Filter out the tests the candidate has already attempted
            var unattemptedMockTests = getallschedules
                .Where(mt => !attemptedschule.Contains(mt.ScheduleExamID))
                .ToList();

            return View("Default", unattemptedMockTests); // Pass the unattempted exams to the view
        }
    }
}

