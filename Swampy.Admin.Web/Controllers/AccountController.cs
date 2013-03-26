using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Swampy.Admin.Web.Controllers
{
    [HandleError]
    public partial class AccountController : AbstractController
    {
        [HttpGet]
        public virtual ActionResult LogOn()
        {
            return View("Index");
        }

        [HttpPost]
        public virtual ActionResult LogOn(string userName, string password)
        {
            if (FormsAuthentication.Authenticate(userName, password))
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("logon", "Invalid username or password");
                return View("Index");
            }
        }

        [HttpPost]
        public virtual ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}