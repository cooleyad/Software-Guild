using SWGDealer.Data;
using SWGDealer.Data.Interfaces;
using SWGDealer.Models;
using SWGDealer.Models.DealerModels;
using SWGDealer.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWGDealer.Controllers
{
    [Authorize(Roles = "admin, sales")]
    public class SalesController : Controller
    {
        ISWGDealerRepo repo = SWGDealerManagerFactory.Create();

        // GET: Sales
        public ActionResult Sales()
        {
            return View();
        }

        public ActionResult Purchase(int id)
        {
            var p = new PurchaseViewModel();
            p.SetPurchaseTypes(repo.GetAllPurchaseTypes());
            p.VehicleId = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            if(ModelState.IsValid)
            {
                var soldVehicle = repo.GetVehicleById(model.VehicleId);
                soldVehicle.VehicleIsSold = true;

                var purchase = new Purchase();
                purchase.Vehicle = soldVehicle;
                purchase.Customer = new Customer
                {
                    Name = model.Name,
                    Street1 = model.Street1,
                    Street2 = model.Street2,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.Zip,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    
                };
                purchase.PurchaseTypeId = model.PurchaseType.PurchaseTypeId;
                purchase.PurchasePrice = model.SalePrice;
                purchase.DatePurchased = DateTime.Now;
                purchase.User=new AppUser
                {
                    UserName = User.Identity.Name
                };
                repo.AddPurchase(purchase);
                RedirectToAction("Sales");
            }
            return View(model);
        }
    }
}