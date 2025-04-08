using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PackageUPIPayment
    {
        [Key]
        public Int64 PackageUPIPaymentID { get; set; }
       
       
        public string BankName { get; set; }
        public Int64 PackagePurchasePaymentID { get; set; }
        public virtual  PackagePurchasePayment PackagePurchasePayment { get; set; }


    }
}
