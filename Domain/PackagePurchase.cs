using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table(" PackagePurchaseTbl")]
    public class PackagePurchase
    {                                               
        [Key]
        public Int64 PackagePurchaseID {  get; set; }
        public DateTime PurchaseDate {  get; set; }
        public DateTime StartDate {  get; set; }
        public Int64 PackageDuration {  get; set; }
     
        public Int64 TestPackageID { get; set; }
        public virtual TestPackage TestPackage { get; set; }
        public string PackagePurchaseTitle { get; set; }

        public Int64 CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<ScheduleExam> ScheduleExam { get; set; }
        public virtual List<PackagePurchasePayment> PackagePurchasePayments { get; set; }
    }
}
