using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SWGDealer.Models.DealerModels;

namespace SWGDealer.Data
{
    public class SWGDealerDbContext :IdentityDbContext
    {
        public SWGDealerDbContext(): base ("GuildCars")
        {
        }

        public DbSet <Contact> Contacts { get; set; }
        public DbSet <Purchase> Purchases { get; set; }
        public DbSet <SalesSpecials> DealerSalesSpecials { get; set; }
        public DbSet <Vehicle> Vehicles { get; set; }
        public DbSet <VehicleMake> VehicleMakes { get; set; }
        public DbSet <VehicleModel> VehicleModels { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
