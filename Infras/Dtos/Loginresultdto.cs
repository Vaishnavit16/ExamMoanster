using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public  class Loginresultdto
    {
        public Int64 LoggedInID { get; set; }
        public string Messgae { get; set; }
        public bool IsLoggedIn { get; set; }
        public string LoggedInName { get; set; }
    }
}
