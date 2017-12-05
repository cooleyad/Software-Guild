using SWGDealer.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using SWGDealer.Models.DealerModels;
using SWGDealer.Models.Identity;

namespace SWGDealer.Data.MockRepos
{
    public class EFDealerRepository : ISWGDealerRepo
    {
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

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
            throw new NotImplementedException();
        }

        public List<SalesSpecials> GetAllSpecials()
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetAllUsers()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
