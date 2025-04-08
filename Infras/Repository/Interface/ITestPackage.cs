using Domain;
using Domain.Enums;
using Infras.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Interface
{
    public interface ITestPackage:IGeneric<TestPackage>
    {    
        Task Add(TestPackageDTO rec);
        Task Edit(TestPackageDTO rec);
        Task<List<TestPackageDTO>> GetAllTestpackagedets();
        Task Delete(long TestPackageID);
      
        Task<TestPackage> GetTestpackage(Int64 id);

        Task<TestPackage> GetByIDD(Int64 id);

        Task<RepoResultDto> purpchasetestpackage(Int64 companyid, PaymentModeEnumss paymentMode);





    }
}
