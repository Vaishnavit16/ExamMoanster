using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table(" MockTestSubjectTbl")]
    public class MockTestSubject
    {
        [Key]
        public Int64 MockTestSubjectID {  get; set; }
        public String SubjectTitle {  get; set; }
        public String SubjectDesc { get; set; }
     
        public Int64 MockTestCategoryID { get; set; }
        public virtual MockTestCategory MockTestCategory { get; set; }
        public virtual List<MockTestQuestion> MockTestQuestions { get; set; }
        public virtual List<MockTest> MockTests { get; set; }
    }
}
