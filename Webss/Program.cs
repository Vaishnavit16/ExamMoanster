using Domain;
using Infras;
using Infras.Repository.Classes;
using Infras.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(
     opt => {
         opt.IOTimeout = TimeSpan.FromMinutes(20);
         opt.Cookie.IsEssential = true;
         opt.Cookie.HttpOnly = true;
     }
    );

builder.Services.AddControllersWithViews();
var scon = builder.Configuration.GetConnectionString("scon");
builder.Services.AddDbContext<Context>(
     op => op.UseLazyLoadingProxies().UseSqlServer(scon)
    );
builder.Services.AddScoped<Icompany, Companyrepo>();
builder.Services.AddScoped<IMockTestQuestion, MockTestQuestionRepo>();
builder.Services.AddScoped<Isiteadmin, Siteadminrepo >();
builder.Services.AddScoped<IOfferDiscount, OfferRepo>();
builder.Services.AddScoped<ITestPackage, TestPackageRepo>();
builder.Services.AddScoped<IQuestion, QuestionRepo>();
builder.Services.AddScoped<IQuestionBank, QuestionBankRepo>();
builder.Services.AddScoped<IQuestionDBcategory, QuestionDBcategoryRepo>();
builder.Services.AddScoped<Icandidate, CandidateRepo>();
builder.Services.AddScoped<IScdeule, ScheduleExamRepo>();
builder.Services.AddScoped<Imocktest, MocktestRepo>();


builder.Services.AddScoped<ImockTestSubject, MockTestSubREepo>();
builder.Services.AddScoped<IMockTestCategory, MockTestCatRepo>();
builder.Services.AddScoped<IMockQuestionOption, MockQuestionOptionRepo>();






var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();


app.Run();
