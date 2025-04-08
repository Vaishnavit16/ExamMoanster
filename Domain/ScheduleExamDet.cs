using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("ScheduleExamDetTbl")]
    public class ScheduleExamDet 
    {
        [Key]
        public Int64 ScheduleExamDetID {  get; set; }
        public Int64 MarksPerQuestion {  get; set; }
        public Int64 PassingMarks {  get; set; }
       
        public Int64 ScheduleExamID { get; set; }
        public virtual ScheduleExam ScheduleExam { get; set; }
       
        public Int64 QuestionBankID { get; set; }
        public virtual QuestionBank QuestionBank { get; set; }
        [NotMapped]
        public Int64 ScheduleExamCandidateID { get; set; }
    }
}
