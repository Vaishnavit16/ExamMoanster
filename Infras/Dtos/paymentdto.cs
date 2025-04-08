using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
  public  class paymentdto
    {
        public Int64 PackagePurchaseID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime StartDate { get; set; }
        public Int64 PackageDuration { get; set; }

        public Int64 TestPackageID { get; set; }
       
        public Int64 CompanyID { get; set; }
        public Int64 PackagePurchasePaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public String TransactionNo { get; set; }
        public Int64 PaymentModeID { get; set; }
        

    }
}
