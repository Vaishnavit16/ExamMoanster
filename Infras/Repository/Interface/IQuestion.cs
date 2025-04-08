using Domain;
using Infras.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Interface
{
    public interface IQuestion : IGeneric<Question>
    {
        Task<QuestionWithOptionsViewModelDTO> AddQuestionWithOptionsAsync(QuestionWithOptionsViewModelDTO model);

        Task Edit(QuestionWithOptionsViewModelDTO model);


        Question GetQuestionById(Int64 id);
        void UpdateQuestion(Question question);
        //Task getbyid(Int64 id);
    }
}

