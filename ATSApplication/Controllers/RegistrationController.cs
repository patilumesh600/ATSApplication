using ATSApplication.Authorised;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATSApplication.Controllers
{
    [SessionAuthorize]
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(FormCollection fc)
        {
            var name = fc["name"];
            var mobileNo = fc["mobileNo"];
            var emailAddress = fc["emailAddress"];
            var password = fc["password"];

            var user = ""; 
            if (user != null)
            {
                Session["User_Id"] = 1; //user.ID;

                return RedirectToAction("Index1", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", new { msg = "failed" });
            }
        }
    }
}