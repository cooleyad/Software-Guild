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
            throw new NotImplementedException();
        }

        public void AddSpecial(SalesSpecials newSpecial)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

        //public void EditUser(UserViewModel model)
        //{
        //    var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
        //    var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    context.Entry(model)
        //}

        public void EditVehicle(Vehicle editedVehicle)
        {
            throw new NotImplementedException();
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

        public List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public AppUser GetUser(string id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
