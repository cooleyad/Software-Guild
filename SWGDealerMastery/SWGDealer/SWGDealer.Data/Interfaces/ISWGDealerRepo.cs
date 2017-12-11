using Microsoft.AspNet.Identity.EntityFramework;
using SWGDealer.Models.DealerModels;
using SWGDealer.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGDealer.Data.Interfaces
{
    public interface ISWGDealerRepo
    {
        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetNewVehicles();
        List<Vehicle> GetUsedVehicles();
        List<Vehicle> GetAllFeatured();
        Vehicle GetVehicleById(int vehicleId);
        void AddVehicle(Vehicle newVehicle);
        void EditVehicle(Vehicle editedVehicle);
        void DeleteVehicle(int id);

        List<AppUser> GetAllUsers();
        AppUser GetUser(string id);
        IEnumerable<IdentityRole> GetAllRoles();
        void AddUser(AppUser user);
        void EditUser(AppUser user);
        void DeleteUser(int id);

        List<VehicleMake> GetAllMakes();
        VehicleMake GetMakeById(int id);
        void AddMake(VehicleMake newMake);
        void EditMake(VehicleMake editedMake);
        void DeleteMake(int id);

        List<VehicleModel> GetAllModels();
        VehicleModel GetModelById(int id);
        void AddModel(VehicleModel newModel);
        void EditModel(VehicleModel editedModel);
        void DeleteModel(int id);

        List<SalesSpecials> GetAllSpecials();
        SalesSpecials GetSpecials(int id);
        void AddSpecial(SalesSpecials newSpecial);
        void EditSpecial(SalesSpecials editedSpecial);
        void DeleteSpecial(int id);

        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void AddContact(Contact newContact);
        void EditContact(Contact editedContact);
        void DeleteContact(int id);

        List<Purchase> GetAllPurchases();
        Purchase GetPurchaseById(int id);
        void AddPurchase(Purchase newPurchase);
        void EditPurchase(Purchase editedPurchase);

        List<PurchaseType> GetAllPurchaseTypes();

    }
}
