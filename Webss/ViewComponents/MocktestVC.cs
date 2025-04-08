using Domain;
using Infras;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Webss.ViewComponents
{
    public class MocktestVC : ViewComponent
    {
        Imocktest repo;
        Context cc;

        public MocktestVC(Imocktest repo, Context cc)
        {
            this.repo = repo;
            this.cc = cc;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!long.TryParse(HttpContext.Session.GetString("CandidateID"), out long candid))
            {
                return Content("Candidate not found in session.");
            }

            var allMockTests = await repo.GetAll();

            var attemptedMockTestIds = this.cc.candidatesPerformance
                .Where(cp => cp.CandidateID == candid)
                .Select(cp => cp.MockTestID)
                .Distinct()
                .ToList();

            var unattemptedMockTests = allMockTests
                .Where(mt => !attemptedMockTestIds.Contains(mt.MockTestID))
                .ToList();

            return View("Default", unattemptedMockTests);
        }

    }
}
