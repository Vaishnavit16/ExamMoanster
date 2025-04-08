using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("CandidatePerformanceTbl")]
    public class CandidatePerformance
    {
        [Key]
        public Int64 CandidatePerformanceID { get; set; }
     
        public Int64 CandidateID { get; set; }
        public virtual Candidate Candidate { get; set; }
  
        public Int64 MockTestID { get; set; }
        public virtual MockTest MockTest { get; set; }
        public virtual List<CandidatePerformanceDet> CandidatePerformanceDets { get; set; } 
    }
}
