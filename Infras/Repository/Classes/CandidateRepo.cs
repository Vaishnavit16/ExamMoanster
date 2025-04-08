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
    public class CandidateRepo : Icandidate
    {
        Context cc;
        public CandidateRepo(Context cc)
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
                var srec = await this.cc.candidates.FindAsync(id);
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

        public async Task<RepoResultDto> EditProfile(EditProfileDto rec, long id)
        {
            RepoResultDto res = new RepoResultDto();
            try
            {
                var oldrec = await this.cc.candidates.FindAsync(id);

                oldrec.Address = rec.Address;
                oldrec.DateOfBirth = rec.DateOfBirth;
                oldrec.Gender = rec.Gender;


                await this.cc.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Profile Edited!!!!!!";
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }

            return res;
        }

        public async Task<EditProfileDto> GetProfile(long id)
        {
            var res = from t in this.cc.candidates
                      where t.CandidateID == id
                      select new EditProfileDto
                      {
                          Address = t.Address,
                          DateOfBirth = t.DateOfBirth,
                          Gender = t.Gender,



                      };

            return await res.FirstOrDefaultAsync();
        }

        public async Task<Loginresultdto> Login(Logindto rec)
        {
            Loginresultdto res = new Loginresultdto();
            var srec = await this.cc.candidates.SingleOrDefaultAsync(p => p.EmailID == rec.EmailID && p.Password == rec.Password);

            if (srec != null)
            {
                res.IsLoggedIn = true;
                res.LoggedInID = srec.CandidateID;
                res.LoggedInName = srec.CandidateName;
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
