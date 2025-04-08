using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("MockTestCategoryTbl")]
    public class MockTestCategory
    {
        [Key]
        public Int64 MockTestCategoryID {  get; set; }
        public String MockTestCategoryName { get; set; }

        public virtual List<MockTestSubject> MockTestSubjects { get; set; }
    }
}
