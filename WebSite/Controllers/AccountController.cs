using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebSite
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(string userName, string password)
        {
            if (userName == "noya" && password == "123")
            {
                FormsAuthentication.RedirectFromLoginPage(userName, false);

                return null;
            }


            return View();
        }

        public ActionResult NotAuthorized()
        {
            return View();
        }
	}
}