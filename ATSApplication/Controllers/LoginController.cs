using ATSApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATSApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            var user_name = fc["user"];
            var password = fc["password"];

            var user = _loginService.ValidateUser(user_name, password);
            if (user != null)
            {
                Session["User_Id"] = user.ID; //user.ID;

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index", new { msg = "failed" });
            }
        }

        //Logout and rediret to Login page
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("", "Login");
        }
    }
}