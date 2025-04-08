using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("CompanyComplaintTbl")]
    public class CompanyComplaint
    {
        [Key]
        public Int64 CompantComplaintID {  get; set; }
        public String ComplaintTitle {  get; set; }
        public DateTime ComplaintDate { get; set; }
        public String ComplaintDesc { get; set; }
        
        public Int64 CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<CompanyComplaintSolution> CompanySolutions { get; set; }


    }
}
