using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infras.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infras.Repository.Classes
{
    public class ScheduleExamRepo: GenRepo<ScheduleExam>, IScdeule
    {

        Context cc;
        public ScheduleExamRepo(Context cc):base(cc) 
        {
            this.cc = cc;
        }

       

        public async Task<List<ScheduleExam>> Finished()
        {
            var today = DateTime.Today;
            var finishedExams = await cc.Set<ScheduleExam>()
                                         .Where(se => se.ScheduleDate.Date <= today)
                                         .ToListAsync();

            

            return finishedExams;
        }
        //public Task<List<ScheduleExam>> Appair()
        //{
        //    throw new NotImplementedException();
        //}
        //public Task<List<ScheduleExam>> New()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<ScheduleExam>> Running()
        {
            var today = DateTime.Today;

           
            var scheduleExams = await cc.Set<ScheduleExam>()
                                               .Where(se => se.ScheduleDate > today)
                                               .ToListAsync();

            return scheduleExams;
        }
    }
}
