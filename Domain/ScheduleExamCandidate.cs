using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("ScheduleExamCandidateTbl")]
    public class ScheduleExamCandidate
    {
        [Key]
        public Int64 ScheduleExamCandidateID {  get; set; }
       
        public Int64 ScheduleExamID { get; set; }
        public virtual ScheduleExam ScheduleExam { get; set; }
      
        public Int64 CandidateID { get; set; }
        public virtual Candidate Candidate { get; set; }

        public virtual List<ScheduleExamResult> ScheduleExamResults { get; set; }   
    }
}
