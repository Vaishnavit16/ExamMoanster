using Domain;
using Infras;
using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webss.CustAuth;


namespace Webss.Controllers
{
    
    
    public class CompanyManageController : Controller
    {
        Icompany repo;
        Context cc;
        ITestPackage repoo;
        public CompanyManageController(Icompany repo,Context cc,ITestPackage repoo)
        {
            this.repo = repo;
            this.cc = cc;
            this.repoo = repoo;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> SignIn(Logindto rec)
        {
            if (ModelState.IsValid)
            {
                var res = await this.repo.Login(rec);

                if (res.IsLoggedIn)
                {

                    var company = await this.repo.Get(res.LoggedInID);

                    if (company != null && company.ActiveFlag)
                    {

                        HttpContext.Session.SetString("LoggedInName", res.LoggedInName);
                        HttpContext.Session.SetString("CompanyID", res.LoggedInID.ToString());


                        //return RedirectToAction("Index", "CompanyHome", new { area = "CompanyArea" });
                        return RedirectToAction("Index", "Purchase");
                    }
                    else
                    {

                        ModelState.AddModelError("", "Your company is inactive. Please contact support.");
                        return View(rec);
                    }
                }


                ModelState.AddModelError("", res.Messgae);
                return View(rec);
            }

            return View(rec);
        }

        //public async Task<IActionResult> SignIn(Logindto rec)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var res = await this.repo.Login(rec);
        //         if (res.IsLoggedIn)
        //         {
        //             HttpContext.Session.SetString("LoggedInName", res.LoggedInName);
        //             HttpContext.Session.SetString("CompanyID", res.LoggedInID.ToString());
        //             return RedirectToAction("Index", "CompanyHome", new { area = "CompanyArea" });
        //         }

        //         ModelState.AddModelError("", res.Messgae);
        //         return View(rec);
        //     }
        //     return View(rec);
        // }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            ViewBag.RegistrationDate = DateTime.Now;
            var model = new CompanyRegisterDto()
            {
                RegistrationDate = DateTime.Now
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(CompanyRegisterDto rec)
        {
         
            if (ModelState.IsValid)
            {
                var res = await this.repo.Register(rec);
                return View("registrationstatus",res);
            }

           
            return View(rec);
        }


        public IActionResult Index()
        {

            var testPackages = (from package in cc.testPackages
                                join detail in cc.testPackageDets on package.TestPackageID equals detail.TestPackageID
                                select new TestpackageandDetail
                                {   TestPackageID=package.TestPackageID,
                                    Price = package.Price,
                                    PackageTitle = package.PackageTitle,
                                    MaxCandidatePerExam = package.MaxCandidatePerExam,
                                 
                                    NoofTest = detail.NoofTest
                                }).ToList();

            return View(testPackages);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(Int64 id)
        {
            var res = await this.repoo.GetByIDD(id);
            if (res == null)
            {
                return NotFound(); // Or handle it in a way that shows an appropriate error message to the user.
            }
            return View(res);
        }



    }
}


