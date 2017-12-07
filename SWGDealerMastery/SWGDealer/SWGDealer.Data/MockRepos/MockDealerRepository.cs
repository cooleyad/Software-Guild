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
        private static List<PurchaseType> _purchaseType;
        private static List<AppUser> _users;
        private static List<VehicleMake> _makes;
        private static List<VehicleModel> _models;
        private static List<Customer> _customers;
        public static List<AppRole> _appRole;

        public MockDealerRepository()
        {
            _appRole = new List<AppRole>()
            {
                new AppRole{Id="1", Name="admin"},
                new AppRole{Id="2", Name="sales"},
                new AppRole{Id="3", Name="disabled"}
            };


            _contacts = new List<Contact>
            {
                new Contact{ContactId=1, FirstName="Alex", LastName="Cooley",
                    Email ="Coolio@gmail.com", Phone="481-516-2342" },

                new Contact{
                    ContactId=2, FirstName="Luna",LastName="The Lunatic",
                    Email="LooneyToons@hotmail.com", Phone="612-BESTDOG" }
            };

            _vehicles = new List<Vehicle>
            {
                new Vehicle{VehicleId=1,
                Vin="1A2B3CDEFGH456789",
                ModelId=1,
                Year=2015,
                BodyStyle="Coupe",
                TransmissionType="Manual",
                Color="Durple",
                InteriorColor="Black",
                Odometer=15000,
                SalePrice=75000,
                MSRP=90000,
                Description="It's got a V8",
                VehicleIsNew=false,
                VehicleFeatured=false,
                VehicleIsSold=false,
                Image=""
                },
                new Vehicle
                {
                VehicleId=2,
                Vin="9H8G7FEDCBA654321",
                ModelId=2,
                Year=2017,
                BodyStyle="SUV",
                TransmissionType="Automatic",
                Color="Silver",
                InteriorColor="Black",
                Odometer=15,
                SalePrice=85000,
                MSRP=95000,
                Description="It's a friggen defender",
                VehicleIsNew=true,
                VehicleFeatured=true,
                VehicleIsSold=false,
                Image=""
                }
            };

            _salesSpecials = new List<SalesSpecials>
            {
                new SalesSpecials{SalesSpecialsId=1,
                SpecialDesc="15% off dealer inventory for first time buyers",
                SpecialsName="YUGE ONE",
                },

                new SalesSpecials{SalesSpecialsId=2,
                SpecialDesc="We gotta move inventory, and move it fast! 45% off MSRP on anything over $35,000",
                SpecialsName="Sellout Sale",
                },

                new SalesSpecials{SalesSpecialsId=3,
                SpecialDesc="It's so crazy, we shouldn't tell you about it... but... " +
                "make us an offer we cannot refuse and we'll talk",
                SpecialsName="Tha Big Kahuna",
                }
            };

            _purchases = new List<Purchase>
            {

            };

            _purchaseType = new List<PurchaseType>
            {
                new PurchaseType{PurchaseTypeId=1, Description="Bank Finance"},
                new PurchaseType{PurchaseTypeId=2, Description="Dealer Finance"},
                new PurchaseType{PurchaseTypeId=3, Description="Straight Cash Homie"}
            };

            _users = new List<AppUser>
            {

                new AppUser{Id="1",
                    FirstName ="Jerry",
                    LastName ="Lundegaard",
                    Email="J.Lundegaard@SWGDealer.com"
                },
                new AppUser{Id="2",
                    FirstName ="Gil",
                    LastName ="Gunderson",
                    Email="G.Gunderson@SWGDealer.com"
                }

            };

            _makes = new List<VehicleMake>
            {
                new VehicleMake{VehicleMakeId=1, VehicleMakeName="Audi"},
                new VehicleMake{VehicleMakeId=2, VehicleMakeName="BMW"},
                new VehicleMake{VehicleMakeId=3, VehicleMakeName="Chevrolet"},
                new VehicleMake{VehicleMakeId=4, VehicleMakeName="Honda"},
                new VehicleMake{VehicleMakeId=5,VehicleMakeName="Land Rover"},
                new VehicleMake{VehicleMakeId=6, VehicleMakeName="Peugeot"},
                new VehicleMake{VehicleMakeId=7, VehicleMakeName="Toyota"},
                new VehicleMake{VehicleMakeId=8, VehicleMakeName="Volkswagen"},
                new VehicleMake{VehicleMakeId=9, VehicleMakeName="Yugo"}
            };

            _models = new List<VehicleModel>
            {
                new VehicleModel{VehicleModelId=1,
                VehicleModelName="S8",
                VehicleMakeId=_makes[1].VehicleMakeId
                },

                new VehicleModel
                {
                    VehicleModelId=2,
                    VehicleModelName="Defender",
                    VehicleMakeId=_makes[5].VehicleMakeId
                },

                new VehicleModel
                {
                    VehicleModelId=3,
                    VehicleModelName="CRX",
                    VehicleMakeId=_makes[4].VehicleMakeId
                }
            };

            _customers = new List<Customer>
            {
            };
        }

        public void AddContact(Contact newContact)
        {
            if (_contacts.Any())
            {
                newContact.ContactId = _contacts.Max(c => c.ContactId) + 1;
            }
            else
            {
                newContact.ContactId = 1;
            }
            _contacts.Add(newContact);
        }

        public void AddMake(VehicleMake newMake)
        {
            if (_makes.Any())
            {
                newMake.VehicleMakeId = _makes.Max(m => m.VehicleMakeId) + 1;
            }
            else
            {
                newMake.VehicleMakeId = 1;
            }
            _makes.Add(newMake);
        }

        public void AddModel(VehicleModel newModel)
        {
            if (_models.Any())
            {
                newModel.VehicleModelId = _models.Max(m => m.VehicleModelId) + 1;
            }
            else
            {
                newModel.VehicleModelId = 1;
            }
            _models.Add(newModel);
        }

        public void AddPurchase(Purchase newPurchase)
        {
            if (_purchases.Any())
            {
                newPurchase.PurchaseId = _purchases.Max(p => p.PurchaseId) + 1;
            }
            else
            {
                newPurchase.PurchaseId = 1;
            }
            _purchases.Add(newPurchase);
        }

        public void AddSpecial(SalesSpecials newSpecial)
        {
            if(_salesSpecials.Any())
            {
                newSpecial.SalesSpecialsId = _salesSpecials.Max(s => s.SalesSpecialsId) + 1;
            }
            else
            {
                newSpecial.SalesSpecialsId = 1;
            }
            _salesSpecials.Add(newSpecial); 
        }

        public void AddUser(AppUser newUser)
        {
            if (_users.Any())
            {
                newUser.Id = _users.Max(u => u.Id) + 1;
            }
            else
            {
                newUser.Id = "1";
            }
            _users.Add(newUser);
        }

        public void AddVehicle(Vehicle newVehicle)
        {
            if (_vehicles.Any())
            {
                newVehicle.VehicleId = _vehicles.Max(v => v.VehicleId) + 1;
            }
            else
            {
                newVehicle.VehicleId = 1;
            }
            _vehicles.Add(newVehicle);
        }

        public void DeleteContact(int id)
        {
            _contacts.RemoveAll(c => c.ContactId == id);
        }

        public void DeleteMake(int id)
        {
            _makes.RemoveAll(m => m.VehicleMakeId == id);
        }

        public void DeleteModel(int id)
        {
            _models.RemoveAll(m => m.VehicleModelId == id);
        }

        public void DeleteSpecial(int id)
        {
            _salesSpecials.RemoveAll(s => s.SalesSpecialsId == id);
        }

        public void DeleteUser(int id)
        {
            _users.RemoveAll(u => u.Id == id.ToString());
        }

        public void DeleteVehicle(int id)
        {
            _vehicles.RemoveAll(v => v.VehicleId == id);
        }

        public void EditContact(Contact editedContact)
        {
            _contacts.RemoveAll(c => c.ContactId == editedContact.ContactId);
            _contacts.Add(editedContact);
        }

        public void EditMake(VehicleMake editedMake)
        {
            _makes.RemoveAll(c => c.VehicleMakeId == editedMake.VehicleMakeId);
            _makes.Add(editedMake);
        }

        public void EditModel(VehicleModel editedModel)
        {
            _models.RemoveAll(m => m.VehicleModelId == editedModel.VehicleModelId);
            _models.Add(editedModel);
        }

        public void EditPurchase(Purchase editedPurchase)
        {
            _purchases.RemoveAll(p => p.PurchaseId == editedPurchase.PurchaseId);
            _purchases.Add(editedPurchase);
        }

        public void EditSpecial(SalesSpecials editedSpecial)
        {
            _salesSpecials.RemoveAll(s => s.SalesSpecialsId == editedSpecial.SalesSpecialsId);
            _salesSpecials.Add(editedSpecial)
;        }

        public void EditUser(AppUser user)
        {
            _users.RemoveAll(u => u.Id == user.Id);
            _users.Add(user);
        }

        public void EditVehicle(Vehicle editedVehicle)
        {
            _vehicles.RemoveAll(v => v.VehicleId == editedVehicle.VehicleId);
            _vehicles.Add(editedVehicle);
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
            return _appRole;
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
            return _vehicles.Where(v => v.VehicleIsNew == true).ToList();
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
            return _vehicles.Where(v => v.VehicleIsNew == false).ToList();
        }

        public AppUser GetUser(string id)
        {
            return _users.FirstOrDefault(u => u.Id == id.ToString());
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return _vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
        }

        public void EditUser(UserViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
