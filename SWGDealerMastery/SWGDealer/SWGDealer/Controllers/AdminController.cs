using SWGDealer.Data.Interfaces;
using SWGDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWGDealer.Data;
using SWGDealer.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SWGDealer.Models.DealerModels;
using System.IO;

namespace SWGDealer.Controllers
{
    public class AdminController : Controller
    {
        ISWGDealerRepo repo = SWGDealerManagerFactory.Create();
        SWGDealerDbContext context = new SWGDealerDbContext();


        [Authorize(Roles = "admin")]
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Add()
        {
            var model = new NewVehicleViewModel();
            model.SetMakes(repo.GetAllMakes());
            model.SetModels(repo.GetAllModels());
            model.SetPurchaseTypes(repo.GetAllPurchaseTypes());
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(NewVehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    string picture = Path.GetFileName(model.Image.FileName);
                    string imgPath = Path.Combine(Server.MapPath("~/Images/"), picture);

                    model.Image.SaveAs(imgPath);
                }
                Vehicle newVehicle = new Vehicle
                {
                    VehicleId = model.VehicleId,
                    Vin = model.VIN,
                    Year = model.Year,
                    BodyStyle = model.BodyStyle,
                    Model = model.GetModel,
                    //Model=new VehicleModel
                    //{
                    //    VehicleModelId = model.GetModel.VehicleModelId,
                    //},
                    Image = "http://localhost:53012/Images/" + model.Image.FileName,
                    Color = model.Color,
                    InteriorColor = model.InteriorColor,
                    Odometer = model.Odometer,
                    MSRP = model.MSRP,
                    SalePrice = model.SalePrice,
                    TransmissionType = model.TransmissionType,
                    Description = model.Description,
                    VehicleFeatured = model.Featured,
                    VehicleIsNew = model.IsNew,

                };
                repo.AddVehicle(newVehicle);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var v = repo.GetVehicleById(id);
            var model = new EditVehicleViewModel {
                VehicleId = v.VehicleId,
                VehicleMakeId = v.Model.VehicleMakeId,
                GetModel = v.Model,
                IsNew = v.VehicleIsNew,
                Year=v.Year,
                VIN=v.Vin,
                BodyStyle=v.BodyStyle,
                TransmissionType=v.TransmissionType,
                Color=v.Color,
                InteriorColor=v.InteriorColor,
                Odometer=v.Odometer,
                SalePrice=v.SalePrice,
                MSRP=v.MSRP,
                Description=v.Description,
                ImagePath=v.Image,
                Featured=v.VehicleFeatured,
            };
            model.SetMakes(repo.GetAllMakes());
            model.SetModels(repo.GetAllModels());
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVehicleViewModel model)
        {
            if (model.Image != null && model.Image.ContentLength>0)
            {
                string picture = Path.GetFileName(model.Image.FileName);
                string imgPath = Path.Combine(Server.MapPath("~/Images/"), picture);

                model.Image.SaveAs(imgPath);
                model.ImagePath = "http://localhost:53012/Images/" + model.Image.FileName;
            }

            if (ModelState.IsValid)
            {
                Vehicle editedVehicle = new Vehicle
                {
                    VehicleId = model.VehicleId,
                    Vin = model.VIN,
                    Year = model.Year,
                    BodyStyle = model.BodyStyle,
                    Model = model.GetModel,
                    Image = model.ImagePath,
                    Color = model.Color,
                    InteriorColor = model.InteriorColor,
                    Odometer = model.Odometer,
                    MSRP = model.MSRP,
                    SalePrice = model.SalePrice,
                    TransmissionType = model.TransmissionType,
                    Description = model.Description,
                    VehicleFeatured = model.Featured,
                    VehicleIsNew = model.IsNew,
                };
                repo.EditVehicle(editedVehicle);
                return RedirectToAction("Admin");
            }
            else
            {
                model.SetMakes(repo.GetAllMakes());
                model.SetModels(repo.GetAllModels());
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            var vehicle = repo.GetVehicleById(id);
            return View(vehicle);
        }

        [HttpPost]
        public ActionResult Delete(Vehicle vehicle)
        {
            repo.DeleteVehicle(vehicle.VehicleId);
            return RedirectToAction("Admin");
        }

        public ActionResult Users()
        {
            var model = repo.GetAllUsers();
            return View(model);
        }

        public ActionResult AddUser()
        {
            var model = new UserViewModel();
            model.SetRoleItems(repo.GetAllRoles());
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            model.AppUser.UserName = model.AppUser.Email;
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (userMgr.FindByName(model.AppUser.UserName) == null)
            {
                var newUser = new AppUser()
                {
                    FirstName = model.AppUser.FirstName,
                    LastName = model.AppUser.LastName,
                    UserName = model.AppUser.UserName,
                    Email = model.AppUser.Email
                };
                userMgr.Create(newUser, model.NewPassword);
            }

            var user = userMgr.FindByName(model.AppUser.UserName);
            var role = context.Roles.SingleOrDefault(r => r.Id == model.Role.Id);
            userMgr.AddToRole(user.Id, role.Name);
            context.SaveChanges();
            return RedirectToAction("Users");
        }

        public ActionResult EditUser(string id)
        {
            var model = new UserViewModel();
            var user = repo.GetAllUsers().FirstOrDefault(u => u.Id == id);
            model.AppUser = repo.GetUser(id);
            model.SetRoleItems(repo.GetAllRoles());
            return View(model);

        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel model)
        {
            model.AppUser.UserName = model.AppUser.Email;
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var user = userMgr.FindById(model.AppUser.Id);

            if (userMgr.FindById(model.AppUser.Id) != null)
            {
                user.FirstName = model.AppUser.FirstName;
                user.LastName = model.AppUser.LastName;
                user.Email = model.AppUser.Email;
                user.UserName = model.AppUser.Email;
                userMgr.Update(user);
            }
            var role = context.Roles.SingleOrDefault(r => r.Id == model.Role.Id);
            string[] allUserRoles = userMgr.GetRoles(user.Id).ToArray();
            userMgr.RemoveFromRoles(user.Id, allUserRoles);
            userMgr.AddToRole(user.Id, role.Name);
            if (role.Name == "disabled")
            {
                userMgr.SetLockoutEnabled(user.Id, true);
                userMgr.SetLockoutEndDate(user.Id, DateTime.Today.AddYears(1000));
                userMgr.Update(user);
            }
            context.SaveChanges();
            return RedirectToAction("Users");
        }

        public ActionResult Models()
        {
            var model = repo.GetAllModels();
            return View(model);
        }

        public ActionResult AddModel()
        {
            var model = new AddModelViewModel();
            model.SetMakes(repo.GetAllMakes());
            return View(model);
        }

        [HttpPost]
        public ActionResult AddModel(AddModelViewModel model)
        {
            VehicleModel vModel = new VehicleModel();

            var modName = model.ModelType;
            vModel.VehicleModelName = modName;
            var userId = User.Identity.GetUserId();
            var user = repo.GetUser(userId);
            var make = repo.GetMakeById(model.VehicleMakeId);
            vModel.User = user;
            vModel.VehicleMakeId = model.VehicleMakeId;
            repo.AddModel(vModel);
            return RedirectToAction("Models");
        }

        public ActionResult Makes()
        {
            var model = repo.GetAllMakes();
            return View(model);
        }

        public ActionResult AddMake()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMake(VehicleMake make)
        {
            var userId = User.Identity.GetUserId();
            var user = repo.GetUser(userId);
            make.User = user;
            repo.AddMake(make);
            return RedirectToAction("Makes");
        }

        public ActionResult AddSpecial()
        {
            return View(new SalesSpecials());
        }

        [HttpPost]
        public ActionResult AddSpecial(SalesSpecials special)
        {
            SalesSpecials specialK = new SalesSpecials
            {
                SpecialsName = special.SpecialsName,
                SpecialDesc = special.SpecialDesc

            };
            repo.AddSpecial(specialK);
            return View(special);
        }

        public ActionResult DeleteSpecial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSpecial(SalesSpecials special)
        {
            repo.DeleteSpecial(special.SalesSpecialsId);
            return RedirectToAction("AddSpecial");
        }
    }
}