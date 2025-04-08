using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infras
{
    public class Context:DbContext
    {
        internal object MockTestQuestionOptions;

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        
        public DbSet<Candidate> candidates { get; set; }
        public DbSet<CandidatePerformance> candidatesPerformance { get; set; }
        public DbSet<CandidatePerformanceDet> candidatePerformanceDets { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<CompanyComplaint> companyComplaints { get; set; }
        public DbSet<CompanyComplaintSolution> companyComplaintSolutions { get; set; }
        public DbSet<CompanyTrail> companyTrails { get; set; }
        public DbSet<MockTest> mockTests { get; set; }
        public DbSet<MockTestCategory> mockTestCategories { get; set; }
        public DbSet<MockTestQuestion> mockTestQuestions { get; set; }
        public DbSet<MockTestSubject> mockTestSubjects { get; set; }
        public DbSet<OfferDiscount> offerDiscounts { get; set; }
        public DbSet<PackagePurchase> packagePurchases { get; set; }
        public DbSet<PackagePurchasePayment> packagePurchasePayments { get; set; }
        public DbSet<PaymentMode> paymentModes { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<QuestionAnswer> questionAnswers { get; set; }
        public DbSet<QuestionBank> questionBanks { get; set; }
        public DbSet<QuestionDBCategory> questionDBCategories { get; set; }
        public DbSet<ScheduleExam> scheduleExams { get; set; }
        public DbSet<ScheduleExamCandidate> scheduleExamCandidates { get; set; }
        public DbSet<ScheduleExamDet> scheduleExamDets { get; set; }
        public DbSet<ScheduleExamResult> ScheduleExamResults { get; set; }
        public DbSet<SiteAdmin> siteAdmins { get; set; }
        public DbSet<TestPackage> testPackages { get; set; }
        public DbSet<TestPackageDet> testPackageDets { get; set; }
        public DbSet<MockTestQueOption> mockTestQueOptions {  get; set; }
       
        public DbSet<PackageCardPayment> packageCardPayments { get; set; }
        public DbSet<PackageUPIPayment> PackageUPIPayments { get; set; }

    }
}
