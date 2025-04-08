using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class CompanyRegisterDto
    {
       
        [Required]
        public String CompanyName { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="EmailID Required")]
        public String EmailID { get; set; }
        [Required]
        public String ContactPersonName { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "10 digits required!")]
        public String ContactNo { get; set; }
        [Required]
        public String CompanyDesc { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        
        public DateTime RegistrationDate { get; set; }
        [Required]
        public bool ActiveFlag { get; set; }
    }
}
