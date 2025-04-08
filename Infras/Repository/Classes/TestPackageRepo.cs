using Domain;
using Domain.Enums;
using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Infras.Repository.Classes
{
    public class TestPackageRepo : GenRepo<TestPackage>, ITestPackage
    {
        Context cc;
        public TestPackageRepo(Context cc) : base(cc)
        {
            this.cc = cc;
        }

        public async Task Add(TestPackageDTO rec)
        {
            var testpackage = new TestPackage
            {
                ApplicationDate = rec.ApplicationDate,
                Price = rec.Price,
                PackageTitle = rec.PackageTitle,
                PackageDesc = rec.PackageDesc,
                MaxCandidatePerExam = rec.MaxCandidatePerExam,

            };

            await cc.testPackages.AddAsync(testpackage);
            await cc.SaveChangesAsync();

            var res = new TestPackageDet
            {
                TestPackageID = testpackage.TestPackageID,
                NoofTest = rec.NoofTest,
                ValidityInMonths = rec.ValidityInMonths,

            };

            await cc.testPackageDets.AddAsync(res);
            await cc.SaveChangesAsync();
        }

        public async Task Edit(TestPackageDTO rec)
        {
            var res = await cc.testPackages
                 .Include(t => t.TestPackageDets)
                 .FirstOrDefaultAsync(t => t.TestPackageID == rec.TestPackageID);

            res.ApplicationDate = rec.ApplicationDate;
            res.Price = rec.Price;
            res.PackageTitle = rec.PackageTitle;
            res.PackageDesc = rec.PackageDesc;
            res.MaxCandidatePerExam = rec.MaxCandidatePerExam;



            var testpackagedets = res.TestPackageDets.FirstOrDefault();
            if (testpackagedets != null)
            {
                testpackagedets.NoofTest = rec.NoofTest;
                testpackagedets.ValidityInMonths = rec.ValidityInMonths;

            }

            cc.Entry(res).State = EntityState.Modified;
            await cc.SaveChangesAsync();
        }




        public async Task Delete(Int64 TestPackageID)
        {
            var test = await cc.testPackages
                .Include(t => t.TestPackageDets)
                .FirstOrDefaultAsync(t => t.TestPackageID == TestPackageID);
            cc.testPackageDets.RemoveRange(test.TestPackageDets);
            cc.testPackages.Remove(test);
            await cc.SaveChangesAsync();
        }

        public async Task<List<TestPackageDTO>> GetAllTestpackagedets()
        {
            var res = from t in cc.testPackages
                      join t1 in cc.testPackageDets on t.TestPackageID equals t1.TestPackageID

                      select new TestPackageDTO
                      {
                          TestPackageID = t.TestPackageID,
                          ApplicationDate = t.ApplicationDate,
                          Price = t.Price,
                          PackageTitle = t.PackageTitle,
                          PackageDesc = t.PackageDesc,
                          MaxCandidatePerExam = t.MaxCandidatePerExam,

                          NoofTest = t1.NoofTest,
                          ValidityInMonths = t1.ValidityInMonths,

                      };
            return await res.ToListAsync();
        }

        public async Task<TestPackage> GetTestpackage(Int64 id)
        {
            return await this.cc.testPackages.FindAsync(id);
        }



        public async Task<TestPackage> GetByIDD(Int64 id)
        {
            return await this.cc.testPackages.FindAsync(id);
        }

        public async Task<RepoResultDto> purpchasetestpackage(long companyid, PaymentModeEnumss paymentMode)
        {
            var res = new RepoResultDto();
          
            try
            {

                PackagePurchase prec = new PackagePurchase();
                prec.PurchaseDate = DateTime.Now;
                prec.CompanyID = companyid;

                this.cc.packagePurchases.AddAsync(prec);
                this.cc.SaveChangesAsync();
               

                res.IsSuccess=true;
                res.Message = "Purchase Successfully";
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;

        }
    }
}

 


