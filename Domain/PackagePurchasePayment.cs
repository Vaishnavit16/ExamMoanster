using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("PackagePurchasePaymentTbl")]
    public class PackagePurchasePayment
    {
        [Key]
        public Int64 PackagePurchasePaymentID {  get; set; }
    
        public Int64 PackagePurchaseID { get; set; }
        public virtual PackagePurchase PackagePurchase { get; set; }
        public DateTime PaymentDate {  get; set; }
        public decimal PaymentAmount { get; set; }
    
     
        public Int64 PaymentModeID { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
        public virtual List<PackageUPIPayment> PackageUPIPayments { get; set; }
        public virtual List<PackageCardPayment> PackageCardPayments { get; set; }

    }
}
