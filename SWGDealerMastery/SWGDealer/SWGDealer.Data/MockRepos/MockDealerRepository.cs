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
    public class MockDealerRepository : ISWGDealerRepo
    {
        private static List <Contact> _contacts;
        private static List<Vehicle> _vehicles;
        private static List<SalesSpecials> _salesSpecials;
        private static List<Purchase> _purchases;
        private static List<AppUser> _users;
        private static List<VehicleMake> _makes;
        private static List<VehicleModel> _models;
        private static List<AppRole> _roles;

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
            return _contacts;
        }

        public List<VehicleMake> GetAllMakes()
        {
            return _makes;
        }

        public List<VehicleModel> GetAllModels()
        {
            return _models;
        }

        public List<Purchase> GetAllPurchases()
        {
            return _purchases;
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return _roles;
        }

        public List<SalesSpecials> GetAllSpecials()
        {
            return _salesSpecials;
        }

        public List<AppUser> GetAllUsers()
        {
            return _users;
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public Contact GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public VehicleMake GetMakeById(int id)
        {
            return _makes.FirstOrDefault(m => m.VehicleMakeId == id);
        }

        public VehicleModel GetModelById(int id)
        {
            return _models.FirstOrDefault(m => m.VehicleModelId == id);
        }

        public List<Vehicle> GetNewVehicles()
        {
            throw new NotImplementedException();
        }

        public Purchase GetPurchaseById(int id)
        {
            return _purchases.FirstOrDefault(p => p.PurchaseId == id);
        }

        public SalesSpecials GetSpecials(int id)
        {
            return _salesSpecials.FirstOrDefault(s => s.SalesSpecialsId == id);
        }

        public List<Vehicle> GetUsedVehicles()
        {
            throw new NotImplementedException();
        }

        public AppUser GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return _vehicles.FirstOrDefault(v => v.VehicleId == id);
        }
    }
}
