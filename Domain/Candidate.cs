
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("CandidateTbl")]
    public class Candidate
    {
        [Key]
        public Int64 CandidateID {  get; set; }
        public string CandidateName { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password {  get; set; }
        public DateTime RegistrationDate {  get; set; }
        public bool ActiveFlag {  get; set; }
        public GenderEnum Gender {  get; set; }

        public virtual List<CandidatePerformance> CandidatePerformances { get; set; }
        public virtual List<ScheduleExamCandidate> ScheduleExamCandidates { get; set; }



    }
}
