using Domain;
using Infras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Webss.ViewComponents
{
    public class ScheduleExamViewComponentVC:ViewComponent
    {
        Context cc;
       
        public ScheduleExamViewComponentVC(Context cc)
        {
            this.cc = cc;
            
        }

        public IViewComponentResult Invoke()
        {
            long candidateId = Convert.ToInt64(HttpContext.Session.GetString("CandidateID"));

            // Query to get the list of ScheduleExams assigned to the candidate, excluding those already marked in ScheduleExamResults
            var scheduleExams = from t in cc.scheduleExams
                                join t1 in cc.scheduleExamCandidates
                                on t.ScheduleExamID equals t1.ScheduleExamID
                                where t1.CandidateID == candidateId &&
                                      !(from t2 in cc.ScheduleExamResults
                                        join t3 in cc.scheduleExamCandidates
                                        on t2.ScheduleExamCandidateID equals t3.ScheduleExamCandidateID
                                        where t3.CandidateID == candidateId
                                        select t2.ScheduleExamCandidateID).Contains(t1.ScheduleExamCandidateID)
                                select t;

            // Pass the results to the view component
            return View(scheduleExams.ToList());
        }
    }
}
    

