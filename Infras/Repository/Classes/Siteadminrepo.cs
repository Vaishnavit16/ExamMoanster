using Domain;
using Infras.Dtos;
using Infras.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Repository.Classes
{
    public class Siteadminrepo:GenRepo<SiteAdmin>,Isiteadmin
    {
        Context cc;
        public Siteadminrepo(Context cc):base(cc)
        {
            this.cc = cc;
        }
        public async Task<RepoResultDto> ChangePassword(ChangePasswordDto rec, long id)
        {
            RepoResultDto res = new RepoResultDto();
            if (rec.NewPassword != rec.ConfirmPassword)
            {
                res.IsSuccess = false;
                res.Message = "Confirm Password and New Password are not Same!";
                return res;
            }

            try
            {
                var srec = await this.cc.siteAdmins.FindAsync(id);
                if (srec.Password != rec.OldPassword)
                {
                    res.IsSuccess = false;
                    res.Message = " Old Password are Not Correct!";
                    return res;
                }
                srec.Password = rec.NewPassword;
                await this.cc.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Password Changed!!!!";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }

       
       
        public async Task<Loginresultdto> Login(Logindto rec)
        {
            Loginresultdto res = new Loginresultdto();
            var srec = await this.cc.siteAdmins.SingleOrDefaultAsync(p => p.EmailID == rec.EmailID && p.Password == rec.Password);

            if (srec != null)
            {
                res.IsLoggedIn = true;
                res.LoggedInID = srec.SiteAdminID;
                res.LoggedInName = srec.Name;
            }
            else
            {
                res.IsLoggedIn = false;
                res.Messgae = "Invalid Email Id or Password!";
            }

            return res;
        }

        
    }
}
