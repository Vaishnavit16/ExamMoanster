using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("QuestionAnswerTbl")]
    public class QuestionAnswer
    {
        [Key]
        public Int64 QuestionAnswerID {  get; set; }
        public String Option {  get; set; }
        public bool IsCorrect {  get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
        public Int64 QuestionID { get; set; }
        public virtual Question Question { get; set; }

    }
}
