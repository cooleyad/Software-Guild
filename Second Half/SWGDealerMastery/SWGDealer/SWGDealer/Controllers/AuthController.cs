using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SWGDealer.Models;
using SWGDealer.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWGDealer.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);

        }

        [HttpPost]
        public ActionResult Login (LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var ctx = Request.GetOwinContext();
            var authMgr = ctx.Authentication;
            var userMgr = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var allUsers = userMgr.Users.ToList();
            var hash = userMgr.HasPassword(allUsers.First().Id);
            AppUser user = userMgr.Find(model.Email, model.Password);

            if (user==null)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }

            var userToLogin = userMgr.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authMgr.SignIn(userToLogin);

            if (string.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(Url.Action("Index"));   
            }
            return Redirect(model.ReturnUrl);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authMgr = ctx.Authentication;

            authMgr.SignOut("ApplicationCookie");

            return RedirectToAction("Login");
        }
    }
}