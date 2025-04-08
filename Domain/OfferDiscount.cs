using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("OfferDiscountTbl")]
    public class OfferDiscount
    {
        [Key]
        public Int64 OfferDiscountID {  get; set; }
        public String OfferTitle {  get; set; }
        public String ApplicableTo {  get; set; }
        public DateTime ToFromDate {  get; set; }
        public decimal DiscountAmount {  get; set; }
        public bool Ispercentile {  get; set; }

    }
}
