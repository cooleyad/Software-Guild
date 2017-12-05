namespace SWGDealer.Data.Migrations
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
            if (userMgr.FindByName("jlundegaard@swgdealer.com") == null)
            {
                var newuser = new AppUser()
                {
                    FirstName = "Jerry",
                    LastName = "Lundegaard",
                    UserName = "jlundegaard@swgdealer.com",
                    Email = "jlundegaard@swgdealer.com"

                };
                userMgr.Create(newuser, "Testing123");
            }
            var user = userMgr.FindByName("jlundegaard@swgdealer.com");
            if (!userMgr.IsInRole(user.Id, "admin"))
            {
                userMgr.AddToRole(user.Id, "admin");
            }

            if (!roleMgr.RoleExists("sales"))
            {
                roleMgr.Create(new IdentityRole() { Name = "sales" });
            }

            if (userMgr.FindByName("ggunderson@swgdealer.com")==null)
            {
                var newuser = new AppUser()
                {
                    FirstName="Gil",
                    LastName="Gunderson",
                    UserName= "ggunderson@swgdealer.com",
                    Email= "ggunderson@swgdealer"
                };
                userMgr.Create(newuser, "Test123");
            }
            var salesUser = userMgr.FindByName("ggunderson@swgdealer.com");
            if(!userMgr.IsInRole(salesUser.Id, "sales"))
            {
                userMgr.AddToRole(salesUser.Id, "sales");
            }
        }
    }
}
