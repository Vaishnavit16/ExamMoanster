using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("MockTestTbl")]
    public class MockTest
    {
        [Key]
        public Int64 MockTestID {  get; set; }
        public String MockTestName {  get; set; }
 
        public Int64 MockTestSubjectID { get; set; }
        public virtual MockTestSubject MockTestSubject { get; set; }

        public Int64 NoofQuestion {  get; set; }
        public Int64 MarksPerQuestion { get; set; }
        public bool IsNegavtive {  get; set; }
        public Int64 PassingMarks { get; set; }
        public int TimeperQuestion {  get; set; }

        public virtual List<CandidatePerformance> CandidatePerformances { get; set; }
        public virtual List<CandidatePerformanceDet> CandidatePerformanceDets { get; set; }



    }
}
