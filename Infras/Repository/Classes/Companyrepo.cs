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
    public class Companyrepo : GenRepo<Company>,Icompany
    {
        Context cc;
        public Companyrepo(Context cc):base(cc)
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
                var srec = await this.cc.companies.FindAsync(id);
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
                var oldrec = await this.cc.companies.FindAsync(id);
            
                oldrec.Address = rec.Address;
                oldrec.ContactPersonName = rec.ContactPersonName;
                oldrec.ContactNo = rec.ContactNo;
               

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

        //public Task<Company> Get(long id)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<Company> Get(long id)
        {
            return await cc.companies
                                 .FirstOrDefaultAsync(c => c.CompanyID == id);
        }


        public async Task<EditProfileDto> GetProfile(long id)
        {
            var res = from t in this.cc.companies
                      where t.CompanyID == id
                      select new EditProfileDto
                      {  
                          Address = t.Address,
                          ContactPersonName = t.ContactPersonName,
                          ContactNo=t.ContactNo,
                         


                      };

            return await res.FirstOrDefaultAsync();
        }

        public async Task<Loginresultdto> Login(Logindto rec)
        {
            Loginresultdto res = new Loginresultdto();
            var srec = await this.cc.companies.SingleOrDefaultAsync(p => p.EmailID == rec.EmailID && p.Password == rec.Password);

            if (srec != null)
            {
                res.IsLoggedIn = true;
                res.LoggedInID = srec.CompanyID;
                res.LoggedInName = srec.CompanyName;
            }
            else
            {
                res.IsLoggedIn = false;
                res.Messgae = "Invalid Email Id or Password!";
            }

            return res;
        }

        public async Task<RepoResultDto> Register(CompanyRegisterDto rec)
        {
            RepoResultDto res = new RepoResultDto();
            try
            {
                Company c = new Company();
                c.CompanyName = rec.CompanyName;
                c.Address = rec.Address;
                c.EmailID = rec.EmailID;
                c.ContactPersonName = rec.ContactPersonName;
                c.ContactNo = rec.ContactNo;
                c.CompanyDesc = rec.CompanyDesc;
                c.Password = rec.Password;
                c.RegistrationDate = rec.RegistrationDate;
                c.ActiveFlag = rec.ActiveFlag;
                    this.cc.companies.Add(c);
                await this.cc.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Company Registered!";

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }

            return res;
        }

       
    }
}

         

