using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("TestPackageTbl")]
    public class TestPackage
    {
        [Key]
        public Int64 TestPackageID {  get; set; }

        public DateTime CreationDate {  get; set; }
        public DateTime ApplicationDate {  get; set; }
        public decimal Price {  get; set; }
        public String PackageTitle { get; set; }
        public String PackageDesc { get; set; }
        public Int64 MaxCandidatePerExam {  get; set; }
        public virtual List<TestPackageDet> TestPackageDets { get; set; }
        public virtual List<PackagePurchase> PackagePurchases { get; set; }

      
    }
}
