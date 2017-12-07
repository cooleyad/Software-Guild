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
            throw new NotImplementedException();
        }

        public void AddModel(VehicleModel newModel)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(int id)
        {
            throw new NotImplementedException();
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

        public List<VehicleMake> GetAllMakes()
        {
            throw new NotImplementedException();
        }

        public List<VehicleModel> GetAllModels()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
