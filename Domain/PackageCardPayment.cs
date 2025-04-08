using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PackageCardPayment
    {
        public Int64 PackageCardPaymentID { get; set; }

        public Int64 PackagePurchasePaymentID { get; set; }
        public string TransactionNo { get; set; }
       

        public virtual PackagePurchasePayment PackagePurchasePayment { get; set; }
    }
}
