using Domain;
using Infras.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Classes
{
    public class QuestionDBcategoryRepo : GenRepo<QuestionDBCategory>, IQuestionDBcategory
    {
        Context cc;
        public QuestionDBcategoryRepo(Context cc) : base(cc)
        {
            this.cc = cc;
        }
    }
}