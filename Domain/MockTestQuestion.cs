using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("MockTestQuestionTbl")]
    public class MockTestQuestion
    {
        [Key]
        public Int64 MockTestQuestionID {  get; set; }

        public Int64 MockTestSubjectID { get; set; }
        public virtual MockTestSubject MockTestSubject { get; set; }
        
        public String Questions {  get; set; }
        [NotMapped]
        public Int64 MockTestID { get; set; }


        public virtual List<MockTestQueOption> MockTestQueOptions { get; set; }
    }
}
