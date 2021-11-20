using ATSApplication.Context;
using ATSApplication.Interfaces;
using ATSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ATSApplication.Services
{
    public class LoginService : ILoginService
    {
        ATSApplicationContext _db = new ATSApplicationContext();

        public ApplicationUser ValidateUser(string username, string password)
        {
            try
            {
                string Encryptedpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                var user = _db.ApplicationUser.Where(x => x.Name == username && x.Password == Encryptedpassword && x.IsActive == true).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                //error_log er = new error_log();
                //er.error_log_date = DateTime.Now;
                //er.exception = ex.Message;
                //er.inner_exception = ex.InnerException != null ? ex.InnerException.ToString() : "";
                //er.method_name = "GetAllVisits";
                //er.service_name = "API Service";
                //er.user_id = 1;
                //er.is_mail_sent = false;
                //_scifferContext.error_log.Add(er);
                //_scifferContext.SaveChanges();

                return null;
            }
        }
    }
}