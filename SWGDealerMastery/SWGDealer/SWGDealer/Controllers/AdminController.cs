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

namespace SWGDealer.Controllers
{
    public class AdminController : Controller
    {
        ISWGDealerRepo repo = SWGDealerManagerFactory.Create();
        SWGDealerDbContext context = new SWGDealerDbContext();


        [Authorize(Roles ="admin")]
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(VehicleViewModel model)
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(VehicleViewModel model)
        {
            return View();
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

            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new IdentityRole() { Name = "admin" });
            }

            if (!roleMgr.RoleExists("sales"))
            {
                roleMgr.Create(new IdentityRole() { Name = "sales" });
            }

            if (userMgr.FindByName(model.AppUser.UserName) == null)
            {
                var newUser = new AppUser()
                {
                    FirstName = model.AppUser.FirstName,
                    LastName=model.AppUser.LastName,
                    UserName=model.AppUser.UserName,
                    Email=model.AppUser.Email
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
            var user= repo.GetAllUsers().FirstOrDefault(u => u.Id == id);
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
            var user = userMgr.FindByName(model.AppUser.UserName);
            if (userMgr.FindByName(model.AppUser.UserName) != null)
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
            if (ModelState.IsValid)
            {
                //model.ModelType = vModel.VehicleModelName;
                //model.VehicleModelId = vModel.VehicleModelId;
                //model.Added = vModel.DateAdded;
                model.ModelType = vModel.VehicleModelName;
                var userId = User.Identity.GetUserId();
                var user = repo.GetUser(userId);
                var make = repo.GetMakeById(model.VehicleMakeId);
                model.User = user;
            }
            //model.VehicleModelId = addModel.VehicleModelId;
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
            return View();
        }

        [HttpPost]
        public ActionResult AddSpecial(SalesSpecials special)
        {
            return View();
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