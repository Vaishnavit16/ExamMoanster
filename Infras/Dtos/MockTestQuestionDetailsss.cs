using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class MockTestQuestionDetailsss
    {
        public Int64 MockTestQuestionID { get; set; }
        public String Questions { get; set; }
        public String Option1 { get; set; }

        public String Option2 { get; set; }

        public String Option3 { get; set; }

        public String Option4 { get; set; }

        public string SelectedAnswer { get; set; }

        public string CorrectAnswer { get; set; }
        
    }
}
