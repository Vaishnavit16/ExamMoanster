using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class TestPackageVM
    {
        public Int64 TestPackageID { get; set; }
    public decimal DiscountedPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public decimal Price { get; set; }
        public String PackageTitle { get; set; }
        public String PackageDesc { get; set; }
        public Int64 MaxCandidatePerExam { get; set; }
        public Int64 TestPackageDetID { get; set; }
        public Int64 NoofTest { get; set; }
        public Int64 ValidityInMonths { get; set; }
    }
}
