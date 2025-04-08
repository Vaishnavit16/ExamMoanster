using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class QuestionWithOptionsViewModelDTO
    {
        public Int64 QuestionID { get; set; }
        public Int64 QuestionBankID { get; set; }
        public String QuestionTitle { get; set; }
        public bool IsObjective { get; set; }
        public List<String> Option { get; set; }
        public List<bool> IsCorrect { get; set; }

        public QuestionWithOptionsViewModelDTO()
        {
            Option = new List<String>();
            IsCorrect = new List<bool>();

        }

    }
}
