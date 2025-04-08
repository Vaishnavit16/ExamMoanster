using Domain;
using Domain.Enums;
using Infras;
using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Webss.Controllers
{
    public class PurchaseController : Controller
    {
        Context cc;
        ITestPackage repoo;
        public PurchaseController(Context cc, ITestPackage repoo)
        {
            this.cc = cc;
            this.repoo = repoo;
        }

        public IActionResult Index()
        {
            var v = from t in cc.testPackages
                    join t1 in cc.testPackageDets
                    on t.TestPackageID equals t1.TestPackageID
                    select new TestPackageVM
                    {
                        TestPackageID = t.TestPackageID,
                        CreationDate = t.CreationDate,
                        ApplicationDate = t.ApplicationDate,
                        Price = t.Price,
                        PackageTitle = t.PackageTitle,
                        PackageDesc = t.PackageDesc,
                        MaxCandidatePerExam = t.MaxCandidatePerExam,
                        TestPackageDetID = t1.TestPackageDetID,
                        NoofTest = t1.NoofTest,
                        ValidityInMonths = t1.ValidityInMonths
                    };
            return View(v.ToList());

        }



        [HttpGet]
        public IActionResult Buy(Int64 id, Int64 data)
        {
            ViewBag.paymentmode = new SelectList(cc.paymentModes.ToList(), "PaymentModeID", "PaymentModeName");

            if (HttpContext.Session.GetString("CompanyID") != null)
            {
                var rec = new TestPackageVM();

                var package = cc.testPackages.Find(id);
                if (package == null)
                {
                    return NotFound("Test package not found.");
                }

                rec.TestPackageID = package.TestPackageID;
                rec.CreationDate = package.CreationDate;
                rec.ApplicationDate = package.ApplicationDate;
                rec.Price = package.Price;
                rec.PackageTitle = package.PackageTitle;
                rec.PackageDesc = package.PackageDesc;
                rec.MaxCandidatePerExam = package.MaxCandidatePerExam;

                var packageDetail = cc.testPackageDets.Find(data);
                if (packageDetail == null)
                {
                    return NotFound("Test package detail not found.");
                }

                rec.TestPackageDetID = packageDetail.TestPackageDetID;
                rec.NoofTest = packageDetail.NoofTest;
                rec.ValidityInMonths = packageDetail.ValidityInMonths;

                
                var companyIdString = HttpContext.Session.GetString("CompanyID");

                
                if (long.TryParse(companyIdString, out long companyId))
                {
                    
                    var existingPurchase = cc.packagePurchases
                        .Where(p => p.CompanyID == companyId && p.TestPackageID == id)
                        .OrderByDescending(p => p.PurchaseDate) 
                        .FirstOrDefault();

                    if (existingPurchase != null)
                    {
                        
                        var expirationDate = existingPurchase.PurchaseDate.AddMonths((int)rec.ValidityInMonths); 

                       
                        if (DateTime.Now < expirationDate)
                        {
                            
                            var monthsRemaining = (expirationDate - DateTime.Now).Days / 30; 
                            TempData["ValidityMessage"] = $"You have already purchased this package. You can buy it again after {monthsRemaining} month(s).";
                            return RedirectToAction("Index"); 
                        }
                    }
                }
                else
                {
                    
                    return RedirectToAction("SignIn", "CompanyManage", new { area = "" });
                }

                return View(rec);
            }

            return RedirectToAction("SignIn", "CompanyManage", new { area = "" });
        }















       


      


        [HttpPost]
        public IActionResult Buy(Int64 PaymentMode, TestPackageVM rec)
        {
            

            if (PaymentMode == 1)
            {
                var a = new PackagePurchase();
                a.CompanyID = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
                a.PurchaseDate = DateTime.Now;
                a.TestPackageID = rec.TestPackageID;
                a.StartDate = DateTime.Now;
                a.PackageDuration = rec.ValidityInMonths;
                a.PackagePurchaseTitle = rec.PackageTitle + (" ") + HttpContext.Session.GetString("CompanyName") + (" ");
                cc.packagePurchases.Add(a);
                cc.SaveChanges();

                var v = new PackagePurchasePayment();
                v.PackagePurchaseID = a.PackagePurchaseID;
                v.PaymentDate = DateTime.Now;
                v.PaymentAmount = rec.Price;
                v.PaymentModeID = PaymentMode;
                cc.packagePurchasePayments.Add(v);
                cc.SaveChanges();
                return RedirectToAction("OrderComplete", new { PMode = PaymentMode });
            }
            if (PaymentMode == 2)
            {
                var a = new PackagePurchase();
                a.CompanyID = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
                a.PurchaseDate = DateTime.Now;
                a.TestPackageID = rec.TestPackageID;
                a.StartDate = DateTime.Now;
                a.PackageDuration = rec.ValidityInMonths;
                a.PackagePurchaseTitle = rec.PackageTitle + (" ") + HttpContext.Session.GetString("CompanyName") + (" ");
                cc.packagePurchases.Add(a);
                cc.SaveChanges();

                var v = new PackagePurchasePayment();
                v.PackagePurchaseID = a.PackagePurchaseID;
                v.PaymentDate = DateTime.Now;
                v.PaymentAmount = rec.Price;
                v.PaymentModeID = PaymentMode;
                cc.packagePurchasePayments.Add(v);
                cc.SaveChanges();

                return RedirectToAction("PaymentGateway", new { id = v.PackagePurchasePaymentID });
            }
            else
            {
                var a = new PackagePurchase();
                a.CompanyID = Convert.ToInt64(HttpContext.Session.GetString("CompanyID"));
                a.PurchaseDate = DateTime.Now;
                a.TestPackageID = rec.TestPackageID;
                a.StartDate = DateTime.Now;
                a.PackageDuration = rec.ValidityInMonths;
                a.PackagePurchaseTitle = rec.PackageTitle + (" ") + HttpContext.Session.GetString("CompanyName") + (" ");
                cc.packagePurchases.Add(a);
                cc.SaveChanges();

                var v = new PackagePurchasePayment();
                v.PackagePurchaseID = a.PackagePurchaseID;
                v.PaymentDate = DateTime.Now;
                v.PaymentAmount = rec.Price;
                v.PaymentModeID = PaymentMode;
                cc.packagePurchasePayments.Add(v);
                cc.SaveChanges();

                return RedirectToAction("ChequePayment", new { id = v.PackagePurchasePaymentID });
            }
        }






        [HttpGet]
        public IActionResult PaymentGateway(Int64 id)
        {
            ViewBag.id = id;
          
            return View();
        }


        [HttpPost]
        public IActionResult PaymentGateway(PackageCardPayment rec)
        {
          
            cc.packageCardPayments.Add(rec);
            cc.SaveChanges();

            return RedirectToAction("OrderComplete", new { PMode = 2 });
        }


        [HttpGet]
        public IActionResult ChequePayment(Int64 id)
        {
            ViewBag.id = id;
           
            return View();
        }


        [HttpPost]
        public IActionResult ChequePayment(PackageUPIPayment rec)
        {
           
            cc.PackageUPIPayments.Add(rec);
            cc.SaveChanges();

            return RedirectToAction("OrderComplete", new { PMode = 5 });
        }
        [HttpGet]
        public IActionResult OrderComplete(int PMode = 0)
        {

            return View();
        }
    }









   }

