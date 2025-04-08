using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("TestPackageDetTbl")]
    public class TestPackageDet
    {
        [Key]
        public Int64 TestPackageDetID {  get; set; }
       
        public Int64 TestPackageID { get; set; }
        public virtual TestPackage TestPackage { get; set; }

        public Int64 NoofTest {  get; set; }
        public Int64 ValidityInMonths {  get; set; }
    }
}
