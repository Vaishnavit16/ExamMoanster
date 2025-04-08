using Infras;
using Microsoft.AspNetCore.Mvc;

namespace Webss.ViewComponents
{
    public class SolvedVC : ViewComponent
    {
        Context cc;
        public SolvedVC(Context cc)
        {
            this.cc = cc;
        }

        public IViewComponentResult Invoke()
        {
            if (!long.TryParse(HttpContext.Session.GetString("CandidateID"), out long candid))
            {
                return Content("Candidate not found in session.");
            }


            var candidatePerformances = cc.candidatesPerformance
                .Where(cp => cp.CandidateID == candid)
                .ToList();

            if (!candidatePerformances.Any())
            {
                return Content("No performance records found.");
            }


            var attemptedMockTestIds = candidatePerformances.Select(cp => cp.MockTestID).Distinct().ToList();


            var attemptedMockTests = cc.mockTests
                .Where(mt => attemptedMockTestIds.Contains(mt.MockTestID))
                .ToList();

            return View("Default", attemptedMockTests);
        }
    }
}



