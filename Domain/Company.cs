using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table(" CompanyTbl")]
    public class Company
    {
        [Key]
        public Int64 CompanyID {  get; set; }
        public String CompanyName { get; set; }
        public String Address { get; set; }
        public String EmailID {  get; set; }
        public String ContactPersonName { get; set; }
        public String ContactNo { get; set; }
        public String CompanyDesc {  get; set; }
        public string Password {  get; set; }
        public DateTime RegistrationDate {  get; set; }
        public bool ActiveFlag {  get; set; }
        public virtual List<CompanyTrail> CompanyTrails { get; set; }
        public virtual List<CompanyComplaint> CompanyComplaints { get; set; }
        public virtual List<QuestionDBCategory> QuestionDBCategories { get; set; } 
        public virtual List<QuestionBank> QuestionBanks { get; set; }
        public virtual List<ScheduleExam> ScheduleExams { get; set; }
        public virtual List<PackagePurchase> PackagePurchases { get; set; }
    }
}
