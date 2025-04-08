using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
    public class ManageQuestionsViewModel
    {
        public int QuestionBankId { get; set; }
        public List<Question> Questions { get; set; }
    }
}
