using Domain;
using Infras.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Interface
{
    public interface Isiteadmin:IGeneric<SiteAdmin>
    {
        Task<Loginresultdto> Login(Logindto rec);
        Task<RepoResultDto> ChangePassword(ChangePasswordDto rec, long id);


    }
}
