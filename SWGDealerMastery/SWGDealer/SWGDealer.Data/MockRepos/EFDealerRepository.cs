using SWGDealer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using SWGDealer.Models.DealerModels;
using SWGDealer.Models.Identity;
using Microsoft.AspNet.Identity;

namespace SWGDealer.Data.MockRepos
{
    public class EFDealerRepository : ISWGDealerRepo
    {
        SWGDealerDbContext context = new SWGDealerDbContext();

        public bool ModelState { get; private set; }

        public void AddContact(Contact newContact)
        {
            throw new NotImplementedException();
        }

        public void AddMake(VehicleMake newMake)
        {
            if (context.VehicleMakes.Count()==0)
            {
                newMake.VehicleMakeId = 1;
            }
            else
            {
                var make = context.VehicleMakes.ToList();
                newMake.DateAdded = DateTime.Now;
                var vehicleId = context.VehicleMakes.Max(c => c.VehicleMakeId);
                newMake.VehicleMakeId = vehicleId + 1;

            }
            context.VehicleMakes.Add(newMake);
            context.SaveChanges();
        }

        public void AddModel(VehicleModel newModel)
        {
            if (context.VehicleModels.Count()==0)
            {
                newModel.VehicleMakeId = 1;
            }
            else
            {
                //newModel.VehicleModelName= new AddModelViewModel().ModelType;
                var model = context.VehicleModels.ToList();
                newModel.Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeId == newModel.VehicleMakeId);
                newModel.DateAdded = DateTime.Now;
                var modelId = context.VehicleModels.Max(m => m.VehicleModelId);
                newModel.VehicleModelId = modelId + 1;
            }
            context.VehicleModels.Add(newModel);
            context.SaveChanges();
            //newModel.Make = context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeId == newModel.Make.VehicleMakeId);
            //newModel.User = context.Users.FirstOrDefault(u => u.Id == newModel.User.UserName);

        }

        public void AddPurchase(Purchase newPurchase)
        {
            if(context.Purchases.Count()==0)
            {
                newPurchase.PurchaseId = 1;
            }
            else
            {
                var max = context.Purchases.Max(p => p.PurchaseId);
                newPurchase.PurchaseId = max;
            }
            newPurchase.User = context.Users.FirstOrDefault(u => u.UserName == newPurchase.User.UserName);
            context.Customer.Add(newPurchase.Customer);
            context.Purchases.Add(newPurchase);
            context.SaveChanges();
        }

        public void AddSpecial(SalesSpecials newSpecial)
        {
            if(context.DealerSalesSpecials.Count()==0)
            {
                newSpecial.SalesSpecialsId = 1;
            }
            else
            {
                var max = context.DealerSalesSpecials.Max(m => m.SalesSpecialsId);
                newSpecial.SalesSpecialsId = max;
            }
            context.DealerSalesSpecials.Add(newSpecial);
            context.SaveChanges();
        }

        public void AddUser(AppUser user)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (userMgr.Users.Any(u => u.UserName == u.Email))
            {
                var addedUser = userMgr.Create(user);
            }
        }

        public void AddVehicle(Vehicle newVehicle)
        {
            if (context.Vehicles.Count() == 0)
            {
                newVehicle.VehicleId = 1;
            }
            else
            {
                newVehicle.Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelId == newVehicle.Model.VehicleModelId);
                var id = context.Vehicles.Max(v => v.VehicleId);
                newVehicle.VehicleId = id + 1;
            }
            context.Vehicles.Add(newVehicle);
            context.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMake(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteModel(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecial(int id)
        {
            var specialDelete = context.DealerSalesSpecials.FirstOrDefault(s => s.SalesSpecialsId == id);
            context.DealerSalesSpecials.Remove(specialDelete);
            context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(int id)
        {
            var vehicleDelete = context.Vehicles.FirstOrDefault(v => v.VehicleId == id);
            context.Vehicles.Remove(vehicleDelete);
            context.SaveChanges();
        }

        public void EditContact(Contact editedContact)
        {
            throw new NotImplementedException();
        }

        public void EditMake(VehicleMake editedMake)
        {
            throw new NotImplementedException();
        }

        public void EditModel(VehicleModel editedModel)
        {
            throw new NotImplementedException();
        }

        public void EditPurchase(Purchase editedPurchase)
        {
            throw new NotImplementedException();
        }

        public void EditSpecial(SalesSpecials editedSpecial)
        {
            throw new NotImplementedException();
        }

        public void EditUser(AppUser user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void EditVehicle(Vehicle editedVehicle)
        {
            context.Entry(editedVehicle).State = System.Data.Entity.EntityState.Modified;
            editedVehicle.Model = context.VehicleModels.FirstOrDefault(m => m.VehicleModelId == editedVehicle.Model.VehicleModelId);
            context.SaveChanges();
        }

        public List<Contact> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllFeatured()
        {
            return context.Vehicles.Where(v => v.VehicleFeatured == true && v.VehicleIsSold == false).ToList();
        }

        public List<VehicleMake> GetAllMakes()
        {
            return context.VehicleMakes.Include("User").ToList();
        }

        public List<VehicleModel> GetAllModels()
        {
            var user = context.Users.ToList();
            var make = context.VehicleMakes.ToList();
            return context.VehicleModels.Include("User").Include("Make").ToList();
        }

        public List<Purchase> GetAllPurchases()
        {
            throw new NotImplementedException();
        }

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            return context.PurchaseTypes.ToList();
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return context.Roles.ToList();
        }

        public List<SalesSpecials> GetAllSpecials()
        {
            return context.DealerSalesSpecials.ToList();
        }

        public List<AppUser> GetAllUsers()
        {
            var users = context.Users.ToList();
            var roles = context.Roles.ToList();

            foreach (var u in users)
            {
                foreach (var r in u.Roles)
                {
                    if (roles.Any(ur => ur.Id == r.RoleId))
                    {
                        var roleFound = roles.First(ur => ur.Id == r.RoleId);

                        u.RoleName = roleFound.Name;
                    }
                }
            }
            return users;
        }

        public List<Vehicle> GetAllVehicles(string type, string searchKey, int minYear, int maxYear, decimal minPrice, decimal maxPrice)
        {
            var carReturn = new List<Vehicle>();
            foreach(var v in context.Vehicles.Include("Model").Include("Model.Make"))
            {
                if((type=="new" && v.VehicleIsNew) || (type=="used" && !v.VehicleIsNew) || (type=="both" && !v.VehicleIsSold))
                {
                    if (v.SalePrice>minPrice && v.SalePrice <maxPrice && v.Year>minYear && v.Year<maxYear)
                    {
                        if (v.Model.VehicleModelName.Contains(searchKey) || v.Model.Make.VehicleMakeName.Contains(searchKey) || v.Year.ToString()==searchKey)
                        {
                            carReturn.Add(v);
                        }
                    }
                }
            }
            return carReturn.Take(20).ToList();
        }

        public Contact GetContactById(int id)
        {
            throw new NotImplementedException();
        }

        public VehicleMake GetMakeById(int id)
        {
            return context.VehicleMakes.FirstOrDefault(m => m.VehicleMakeId == id);
        }

        public VehicleModel GetModelById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetNewVehicles()
        {
            return context.Vehicles.Where(v => v.VehicleIsNew == true && v.VehicleIsSold==false).ToList();
        }

        public Purchase GetPurchaseById(int id)
        {
            throw new NotImplementedException();
        }

        public SalesSpecials GetSpecials(int id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetUsedVehicles()
        {
            return context.Vehicles.Where(v => v.VehicleIsNew == false && v.VehicleIsSold==false).ToList();
        }

        public AppUser GetUser(string id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return context.Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
        }
    }
}
