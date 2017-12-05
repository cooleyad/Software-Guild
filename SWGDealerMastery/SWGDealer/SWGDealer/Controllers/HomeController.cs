using SWGDealer.Data;
using SWGDealer.Data.Interfaces;
using SWGDealer.Models.DealerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWGDealer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        ISWGDealerRepo repo = SWGDealerManagerFactory.Create();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult Specials()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View(new Contact());
        }

        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                repo.AddContact(model);
                return RedirectToAction("Index");   
            }
            return View(model);
        }
    }
}