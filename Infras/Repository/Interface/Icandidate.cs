using Infras.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Interface
{
    public interface Icandidate
    {
        Task<Loginresultdto> Login(Logindto rec);
        Task<RepoResultDto> ChangePassword(ChangePasswordDto rec, Int64 id);
        Task<EditProfileDto> GetProfile(Int64 id);
        Task<RepoResultDto> EditProfile(EditProfileDto rec, Int64 id);
    }
}
