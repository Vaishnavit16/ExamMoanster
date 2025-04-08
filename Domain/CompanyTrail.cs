using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("CompanyTrailTbl")]
    public class CompanyTrail
    {
        [Key]
        public Int64 CompanyTrailID {  get; set; }
        public DateTime TrailStartDate {  get; set; }
        public DateTime TrailEndDate { get; set; }
        public bool TrailActiveFlag {  get; set; }
        
        public Int64 CompanyID { get; set; }
        public virtual Company Company { get; set; }

    }
}
