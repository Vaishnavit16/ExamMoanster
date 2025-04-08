using Domain;
using Infras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Infras.Dtos;

namespace Webss.ViewComponents
{
    public class AppairViewComponentVC : ViewComponent
    {
        private readonly Context _context;

        public AppairViewComponentVC(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Retrieve the CandidateID from session
            long candidateId = Convert.ToInt64(HttpContext.Session.GetString("CandidateID"));

            // Query to get the exams that have been completed (submitted and stored in ScheduleExamResults)
            var submittedExams = from t in _context.scheduleExams
                                 join t1 in _context.scheduleExamCandidates
                                 on t.ScheduleExamID equals t1.ScheduleExamID
                                 join t2 in _context.ScheduleExamResults
                                 on t1.ScheduleExamCandidateID equals t2.ScheduleExamCandidateID
                                 where t1.CandidateID == candidateId
                                 select new ExamViewModel
                                 {
                                     ScheduleExamID = t.ScheduleExamID,
                                     CompanyName = t.Company.CompanyName,
                                     ScheduleDate = t.ScheduleDate,
                                     ExamDate = t.ExamDate,
                                     StartTime = t.StartTime,
                                     EndTime = t.EndTime,
                                     ObtainedMarks = t2.ObtainedMarks,
                                     Result = t2.Result
                                 };

            return View(submittedExams.ToList());
        }
    }
}
