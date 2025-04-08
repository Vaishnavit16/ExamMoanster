using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class ScheduleExamVM
    {
        public Int64 ScheduleExamID { get; set; }
        public DateTime ScheduleDate { get; set; }
     public string QuestionBankTitle { get; set; }
        public string CompanyName {  get; set; }
        public Int64 CompanyID { get; set; }
        public Int64 PackagePurchaseID { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsResultOpen { get; set; }
        public bool IsObjective { get; set; }
        public Int64 ScheduleExamDetID { get; set; }

        public Int64 QuestionBankID { get; set; }
        public Int64 MarksPerQuestion { get; set; }
        public Int64 PassingMarks { get; set; }

        public string PackagePurchaseTitle { get; set; }

    }
}
