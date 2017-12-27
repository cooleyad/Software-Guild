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
                    VehicleMakeId = 1,
                    VehicleModelName = "S8",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleModel
                {
                    Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeName == "Honda"),
                    VehicleMakeId = 4,
                    VehicleModelName = "Civic",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleModel
                {
                    Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeName == "Toyota"),
                    VehicleModelName = "Camry",
                    VehicleMakeId = 7,
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleModel
                {
                    Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeName == "Yugo"),
                    VehicleMakeId = 9,
                    VehicleModelName = "The Proletariat's Car",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                },
                new VehicleModel
                {
                    Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeName == "Land Rover"),
                    VehicleMakeId = 5,
                    VehicleModelName = "Defender",
                    DateAdded = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.UserName == "jlundegaard@swgdealer.com")
                }
                );
            context.SaveChanges();

            context.PurchaseTypes.AddOrUpdate(p => p.Description,
                new PurchaseType { Description = "Bank" },
                new PurchaseType { Description = "Cash" },
                new PurchaseType { Description = "Dealer" }

                );
            context.SaveChanges();

            context.Vehicles.AddOrUpdate(v => v.Vin,
               new Vehicle
               {
                   Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelName == "S8"),
                   Vin = "1A2B3CDEFGH456789",
                   Year = 2017,
                   BodyStyle = "Sedan",
                   TransmissionType = "Automatic",
                   Color = "Durple",
                   InteriorColor = "Black",
                   Odometer = 50,
                   SalePrice = 75000,
                   MSRP = 80000,
                   Description = "It's gota V8",
                   Image = "http://localhost:53012/Images/S8.jpg",
                   VehicleIsNew = true,
                   VehicleFeatured = true,
                   VehicleIsSold = false
               },
               new Vehicle
               {
                   Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelName == "Camry"),
                   Vin = "1A2B3CDEFGH456789",
                   Year = 2017,
                   BodyStyle = "Sedan",
                   TransmissionType = "Automatic",
                   Color = "Silver",
                   InteriorColor = "Gray",
                   Odometer = 0,
                   SalePrice = 20000,
                   MSRP = 25000,
                   Description = "It's a Camry, not much to say, it'll get you on your way",
                   Image = "http://localhost:53012/Images/Camry.png",
                   VehicleIsNew = true,
                   VehicleFeatured = true,
                   VehicleIsSold = false
               },
               new Vehicle
               {
                   Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelName == "Civic"),
                   Vin = "1A2B3CDEFGH456789",
                   Year = 2017,
                   BodyStyle = "Coupe",
                   TransmissionType = "Manual",
                   Color = "Red",
                   InteriorColor = "Black",
                   Odometer = 0,
                   SalePrice = 20000,
                   MSRP = 25000,
                   Description = "Civic Coupe, for the practical that still want to have fun",
                   Image = "http://localhost:53012/Images/CivicCoupe.jpg",
                   VehicleIsNew = true,
                   VehicleFeatured = true,
                   VehicleIsSold = false
               },
               new Vehicle
               {
                   Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelName == "Defender"),
                   Vin = "1A2B3CDEFGH456789",
                   Year = 2017,
                   BodyStyle = "SUV",
                   TransmissionType = "Manual",
                   Color = "Black",
                   InteriorColor = "Black",
                   Odometer = 0,
                   SalePrice = 20000,
                   MSRP = 25000,
                   Description = "It's a friggen Defender",
                   Image = "http://localhost:53012/Images/Defender.jpg",
                   VehicleIsNew = true,
                   VehicleFeatured = true,
                   VehicleIsSold = false
               },
               new Vehicle
               {
                   Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelName == "Civic"),
                   Vin = "1A2B3CDEFGH456789",
                   Year = 2017,
                   BodyStyle = "Coupe",
                   TransmissionType = "Manual",
                   Color = "Blue",
                   InteriorColor = "Black",
                   Odometer = 0,
                   SalePrice = 20000,
                   MSRP = 25000,
                   Description = "Civic Coupe, for the practical that still want to have fun",
                   Image = "http://localhost:53012/Images/CivicCoupe.jpg",
                   VehicleIsNew = true,
                   VehicleFeatured = true,
                   VehicleIsSold = false
               },
               new Vehicle
               {
                   Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelName == "Civic"),
                   Vin = "1A2B3CDEFGH456789",
                   Year = 2017,
                   BodyStyle = "Sedan",
                   TransmissionType = "Automatic",
                   Color = "Silver",
                   InteriorColor = "Black",
                   Odometer = 0,
                   SalePrice = 20000,
                   MSRP = 25000,
                   Description = "Civic Sedan, it'll never let you down",
                   Image = "http://localhost:53012/Images/Civic.jpg",
                   VehicleIsNew = false,
                   VehicleFeatured = true,
                   VehicleIsSold = false
               },
               new Vehicle
               {
                   Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelName == "The Proletariat's Car"),
                   Vin = "1A2B3CDEFGH456789",
                   Year = 2017,
                   BodyStyle = "Sedan",
                   TransmissionType = "Manual",
                   Color = "Beige",
                   InteriorColor = "Beige",
                   Odometer = 1000000000,
                   SalePrice = 20000,
                   MSRP = 25000,
                   Description = "If you think that you should not look wealthier than your brethren, then boy do we have the right car for you",
                   Image = "http://localhost:53012/Images/Yugo.jpg",
                   VehicleIsNew = false,
                   VehicleFeatured = true,
                   VehicleIsSold = false
               },
               new Vehicle
               {
                   Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelName == "Civic"),
                   Vin = "1A2B3CDEFGH456789",
                   Year = 2017,
                   BodyStyle = "Sedan",
                   TransmissionType = "Automatic",
                   Color = "Silver",
                   InteriorColor = "Black",
                   Odometer = 0,
                   SalePrice = 20000,
                   MSRP = 25000,
                   Description = "Civic Sedan, it'll never let you down",
                   Image = "http://localhost:53012/Images/Civic.jpg",
                   VehicleIsNew = false,
                   VehicleFeatured = true,
                   VehicleIsSold = false
               },
               new Vehicle
               {
                   Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelName == "Civic"),
                   Vin = "1A2B3CDEFGH456789",
                   Year = 2017,
                   BodyStyle = "Sedan",
                   TransmissionType = "Automatic",
                   Color = "Silver",
                   InteriorColor = "Black",
                   Odometer = 0,
                   SalePrice = 20000,
                   MSRP = 25000,
                   Description = "Civic Sedan, it'll never let you down",
                   Image = "http://localhost:53012/Images/Civic.jpg",
                   VehicleIsNew = false,
                   VehicleFeatured = true,
                   VehicleIsSold = false
               }
               );
        }

    }
}
