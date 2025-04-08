using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ScheduleExam
    {
        [Key]
        public Int64 ScheduleExamID { get; set; }

        public Int64 CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsResultOpen { get; set; }
        public bool IsObjective { get; set; }

        public Int64 PackagePurchaseID { get; set; }
        public virtual PackagePurchase PackagePurchase { get; set; }
        public virtual List<ScheduleExamCandidate> ScheduleExamCandidates { get; set; }
        public virtual List<ScheduleExamDet> ScheduleExamDets { get; set; }
    }
}
