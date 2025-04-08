using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("CompanyComplaintSolutionTbl")]
    public  class CompanyComplaintSolution
    {
        [Key]
        public Int64 CompanyComplaintSolutionID {  get; set; }
        public DateTime SolutionDate { get; set; }
        public String SolutionDesc { get; set; }
        public String SolutionTitle { get; set; }
       
        public Int64 CompantComplaintID { get; set; }
        public virtual CompanyComplaint CompantComplaint { get; set; }
    }
}
