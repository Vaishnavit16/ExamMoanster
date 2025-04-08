using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("SiteAdminTbl")]
    public class SiteAdmin
    {
        [Key]
     
        public Int64 SiteAdminID { get; set; }
       
        public String Name { get; set; }
     
        public String EmailID { get; set; }
      
        public String Mobileno {  get; set; }
   
        public String Password {  get; set; }

    }
}
