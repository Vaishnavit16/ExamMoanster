using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
   public class QuestionAnswerVM
    {
        public Int64 MockTestSubjectID { get; set; }
        public Int64 MocktestQueOptionID { get; set; }
        public Int64 MockTestQuestionID { get; set; }
        public string Question { get; set; }
        public string Option { get; set; }
        public string Option1 { get; set; }
        public bool IsCurrect1 { get; set; }
        public string Option2 { get; set; }
        public bool IsCurrect2 { get; set; }
        public string Option3 { get; set; }
        public bool IsCurrect3 { get; set; }
        public string Option4 { get; set; }
        public bool IsCurrect4 { get; set; }

        public Int64 MockTestQueOptionID1 { get; set; }
        public Int64 MockTestQueOptionID2 { get; set; }
        public Int64 MockTestQueOptionID3 { get; set; }
        public Int64 MockTestQueOptionID4 { get; set; }
    }
}
