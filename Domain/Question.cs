using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("QuestionTbl")]
    public class Question
    {
        [Key]
        public Int64 QuestionID {  get; set; }
        public String QuestionTitle {  get; set; }
        public bool IsObjective {  get; set; }

        public Int64 QuestionBankID { get; set; }
        public virtual QuestionBank QuestionBank { get; set; }
       
        public virtual List<QuestionAnswer> QuestionAnswers { get; set; }

        public Question()
        {
            QuestionAnswers = new List<QuestionAnswer>();
        }
    }
}
