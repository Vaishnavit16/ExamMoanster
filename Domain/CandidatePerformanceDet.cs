using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("CandidatePerformanceDetTbl")]
    public class CandidatePerformanceDet
    {
        [Key]
        public Int64 CandidatePerformanceDetID {  get; set; }
        public Int64 SolvedQuestion {  get; set; }
        public Int64 ObtainedMarks {  get; set; }
 
        public Int64 MockTestID { get; set; }
        public virtual MockTest MockTest { get; set; }
       
        public Int64 CandidatePerformanceID { get; set; }
        public virtual CandidatePerformance CandidatePerformance { get; set; }  
    }
}
