using SWGDealer.Data.Interfaces;
using SWGDealer.Models;
using SWGDealer.Models.DealerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWGDealer.Data;
using SWGDealer.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SWGDealer.Controllers
{
    public class AdminController : Controller
    {
        ISWGDealerRepo repo = SWGDealerManagerFactory.Create();


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

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Vehicle vehicle)
        {
            return View();
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
            var context = new SWGDealerDbContext();
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
            model.SetRoleItems(repo.GetAllRoles());
            model.AppUser = repo.GetUser(id);
            return View(model);

        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel user)
        {
            return View();
        }

        public ActionResult AddModel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddModel(VehicleModel model)
        {
            return View();
        }

        public ActionResult AddMake()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMake(VehicleMake make)
        {
            return View();
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
    }
}