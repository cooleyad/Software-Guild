﻿using SWGDealer.Data.Interfaces;
using SWGDealer.Models;
using SWGDealer.Models.DealerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWGDealer.Data;

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
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel user)
        {
            return View();
        }

        public ActionResult EditUser()
        {
            return View();
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