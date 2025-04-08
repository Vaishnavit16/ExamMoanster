using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class EditProfileDto
    {
       
        public String CompanyName { get; set; }
        public String Address { get; set; }
        public String ContactPersonName { get; set; }
        public String ContactNo { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}
