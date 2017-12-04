using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SWGDealer.Data;
using SWGDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWGDealer.Models.Identity;
namespace SWGDealer.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });


            app.CreatePerOwinContext(() => new SWGDealerDbContext());

            app.CreatePerOwinContext<UserManager<AppUser>>((options, context) => new UserManager<AppUser>
            (new UserStore<AppUser>(context.Get<SWGDealerDbContext>())));

            app.CreatePerOwinContext(() => new SWGDealerDbContext());

            app.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context) => new RoleManager<IdentityRole>
            (new RoleStore<IdentityRole>(context.Get<SWGDealerDbContext>())));
        }
    }
}