using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("QuestionBankTbl")]
    public class QuestionBank
    {
        [Key]
        public Int64 QuestionBankID {  get; set; }
        public String QuestionBankTitle { get; set; }


        public Int64 QuestionDBCategoryID { get; set; }
        public virtual QuestionDBCategory QuestionDBCategory { get; set; }


        public Int64 CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<ScheduleExamDet> ScheduleExamDets { get; set; }
    }
}
