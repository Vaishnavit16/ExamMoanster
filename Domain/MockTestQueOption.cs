using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MockTestQueOption
    {
        [Key]
        public Int64 MocktestQueOptionID { get; set; }
      
        public Int64 MockTestQuestionID { get; set; }

        public string Option { get; set; }
        public bool IsCurrect { get; set; }
        [NotMapped]
        public bool Selected { get; set; }

        public virtual MockTestQuestion MockTestQuestion { get; set; }
    }
}
