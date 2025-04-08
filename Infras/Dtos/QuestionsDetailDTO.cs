using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class QuestionsDetailDTO
    {

        public string QuestionTitle { get; set; }
        public bool IsObjective { get; set; }
        public List<AnserDetailDTO> Answers { get; set; }
    }
}
