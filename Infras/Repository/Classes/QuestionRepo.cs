using Domain;
using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Classes
{
    public class QuestionRepo : GenRepo<Question>, IQuestion
    {
        Context cc;
        public QuestionRepo(Context cc) : base(cc)
        {
            this.cc = cc;
        }



        public async Task<QuestionWithOptionsViewModelDTO> AddQuestionWithOptionsAsync(QuestionWithOptionsViewModelDTO model)
        {

            var question = new Question
            {
                QuestionTitle = model.QuestionTitle,
                IsObjective = model.IsObjective,
                QuestionBankID = model.QuestionBankID
            };


            cc.questions.Add(question);
            await cc.SaveChangesAsync();

            var answers = new List<QuestionAnswer>();


            for (int i = 0; i < model.Option.Count; i++)
            {
                var isCorrect = model.IsCorrect[i];

                var answer = new QuestionAnswer
                {
                    Option = model.Option[i],
                    IsCorrect = isCorrect,
                    QuestionID = question.QuestionID
                };


                answers.Add(answer);
            }


            await cc.questionAnswers.AddRangeAsync(answers);
            await cc.SaveChangesAsync();


            return model;
        }

        public Task Edit(QuestionWithOptionsViewModelDTO model)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(Int64 id)
        {
            return cc.questions
                       .FirstOrDefault(q => q.QuestionID == id);  // Assuming QuestionID is the primary key
        }

        public void UpdateQuestion(Question question)
        {
            cc.questions.Update(question);  // Update the question in the DbContext
            cc.SaveChanges();  // Save changes to the database
        }
    }
}




    

    
