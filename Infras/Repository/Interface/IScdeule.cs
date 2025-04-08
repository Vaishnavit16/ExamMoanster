using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infras.Repository.Interface
{
    public interface IScdeule : IGeneric<ScheduleExam>
    {
        Task<List<ScheduleExam>> Running();
        Task<List<ScheduleExam>> Finished();
        //Task<List<ScheduleExam>> New();
        //Task<List<ScheduleExam>> Appair();
    }
}