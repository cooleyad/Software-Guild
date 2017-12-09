namespace SWGDealer.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SWGDealer.Models.DealerModels;
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

            if (!roleMgr.RoleExists("disabled"))
            {
                roleMgr.Create(new IdentityRole() { Name = "disabled" });
            }

            context.DealerSalesSpecials.AddOrUpdate(s => s.SpecialsName,
                new SalesSpecials
                {
                    SpecialDesc = "15% off dealer inventory for first time buyers",
                    SpecialsName = "YUGE ONE",
                },

                new SalesSpecials
                {
                    SpecialDesc = "We gotta move inventory, and move it fast! 45% off MSRP on anything over $35,000",
                    SpecialsName = "Sellout Sale",
                },

                new SalesSpecials
                {
                    SpecialDesc = "It's so crazy, we shouldn't tell you about it... but... " +
                "make us an offer we cannot refuse and we'll talk",
                    SpecialsName = "Tha Big Kahuna",
                }
            );
            context.SaveChanges();

            context.VehicleMakes.AddOrUpdate(m => m.VehicleMakeName,
                 new VehicleMake
                 {
                     VehicleMakeName = "Audi",
                     DateAdded = DateTime.Now,
                     User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                 },
                new VehicleMake
                {
                    VehicleMakeName = "BMW",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleMake
                {
                    VehicleMakeName = "Chevrolet",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleMake
                {
                    VehicleMakeName = "Honda",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleMake
                {
                    VehicleMakeName = "Land Rover",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleMake
                {
                    VehicleMakeName = "Peugeot",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleMake
                {
                    VehicleMakeName = "Toyota",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleMake
                {
                    VehicleMakeName = "Volkswagen",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleMake
                {
                    VehicleMakeName = "Yugo",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                }
                );
            context.SaveChanges();

            context.VehicleModels.AddOrUpdate(m => m.VehicleModelName,
                new VehicleModel
                {
                    Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeName == "Audi"),
                    VehicleModelName = "S8",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleModel
                {
                    Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeName == "Honda"),
                    VehicleModelName = "Civic",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleModel
                {
                    Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeName == "Toyota"),
                    VehicleModelName = "Camry",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleModel
                {
                    Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeName == "Yugo"),
                    VehicleModelName = "The Proletariat's Car",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                }
                );
            context.SaveChanges();
        }
    }
}
