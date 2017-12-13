using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SWGDealer.Data;
using SWGDealer.Models;
using SWGDealer.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SWGDealer.Controllers
{
    public class AuthController : Controller
    {
        SWGDealerDbContext context = new SWGDealerDbContext();
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
        public ActionResult Login(LoginViewModel model)
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

            if (user == null || user.LockoutEnabled==true)
            {
                return Redirect(Url.Action("Login", "Auth"));
            }


            var userToLogin = userMgr.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authMgr.SignIn(userToLogin);

            if (string.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(Url.Action("Index", "Home"));
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

        [Authorize(Roles = "admin, sales")]
        public ActionResult UpdatePassword()
        {
            return View();
        }

        [Authorize(Roles = "admin, sales")]
        [HttpPost]
        public async Task<ActionResult> UpdatePassword(UpdatePasswordViewModel model, string userId, string newPassword)
        {
            SWGDealerDbContext context = new SWGDealerDbContext();
            UserStore<AppUser> store = new UserStore<AppUser>(context);
            UserManager<AppUser> userManager = new UserManager<AppUser>(store);
            userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return View("UpdatePassword");
            }

            else
            {
                newPassword = model.ConfirmPassword;
                string hashedNewPassword = userManager.PasswordHasher.HashPassword(newPassword);
                AppUser identityUser = await store.FindByIdAsync(userId);
                await store.SetPasswordHashAsync(identityUser, hashedNewPassword);
                await store.UpdateAsync(identityUser);

                TempData["PasswordUpdate"] = "Password has been successfully updated!";
                return View("UpdatePassword");
            }
        }
    }
}   