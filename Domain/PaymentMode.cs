
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    [Table("PaymentModeTbl")]
    public class PaymentMode
    {
       
                                                            
        [Key]
        public Int64 PaymentModeID { get; set; }
        public string PaymentModeName { get; set; }
        public virtual List<PackagePurchasePayment> PackagePurchasePayment { get; set; }


    }
}
