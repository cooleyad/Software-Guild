namespace SWGDealer.Models.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SWGDealer.Models.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SWGDealer.Data.SWGDealerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SWGDealer.Data.SWGDealerDbContext context)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new IdentityRole() { Name = "admin" });
            }
            if (userMgr.FindByName("W.JonesFace@SWGDealer.com") == null)
            {
                var newuser = new AppUser()
                {
                    FirstName = "Whalen",
                    LastName = "JonesFace",
                    Email = "w.jonesface@swgdealer.com",
                    Role = "admin"
                };
                userMgr.Create(newuser, "Testing123");
            }
            var user = userMgr.FindByName("w.jonesface@swgdealer.com");
            if (!userMgr.IsInRole(user.Id, "admin"))
            {
                userMgr.AddToRole(user.Id, "admin");
            }


            if (!roleMgr.RoleExists("sales"))
            {
                roleMgr.Create(new IdentityRole() { Name = "sales" });
            }
            if (userMgr.FindByName("j.lundegaard@swgdealer.com") == null)
            {
                var newuser = new AppUser()
                {
                    FirstName = "Jerry",
                    LastName = "Lundegaard",
                    Email = "j.lundegaard@swgdealer.com",
                    Role = "sales"

                };
                userMgr.Create(newuser, "Testing456");
            }
            var userMan = userMgr.FindByName("j.lundegaard@swgdealer.com");
            if (!userMgr.IsInRole(userMan.Id, "sales"))
            {
                userMgr.AddToRole(userMan.Id, "sales");
            }

        }
    }
}
