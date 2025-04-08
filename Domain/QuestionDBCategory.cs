using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("QuestionDBCategoryTbl")]
    public class QuestionDBCategory
    {
        [Key]
        public Int64 QuestionDBCategoryID {  get; set; }
        public String QuestionDBCategoryName {  get; set; }
   
        public Int64 CompanyID { get; set; }
        public virtual Company Company { get; set; }
    public virtual List<QuestionBank> QuestionBanks { get; set; }
    }
}
