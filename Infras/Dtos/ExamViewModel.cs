using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class ExamViewModel
    {
        public long ScheduleExamID { get; set; }
        public string CompanyName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ObtainedMarks { get; set; }
        public string Result { get; set; }
    }
}
