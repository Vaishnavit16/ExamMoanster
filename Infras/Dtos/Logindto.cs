
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class Logindto
    {
        [Required(ErrorMessage = "EmailID Required")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Password Requird")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
