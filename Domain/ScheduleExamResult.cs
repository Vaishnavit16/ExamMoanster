using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("ScheduleExamResultTbl")]
    public class ScheduleExamResult
    {
        [Key]
        public Int64 ScheduleExamResultID { get; set; }
        public DateTime ResultDate { get; set; }
        public string Result { get; set; }
        [NotMapped]
        public Int64 ScheduleExamID { get; set; }
        public Int64 SolvedQuestions { get; set; }
        public Int64 ObtainedMarks { get; set; }
        public Int64 ScheduleExamCandidateID { get; set; }
        public virtual ScheduleExamCandidate ScheduleExamCandidate { get; set; }
        public bool  GenerationFlag {get;set;}


    }
}
