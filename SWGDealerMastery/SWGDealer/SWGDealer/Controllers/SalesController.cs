using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWGDealer.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Sales()
        {
            return View();
        }

        public ActionResult Purchase()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseviewModel model)
        {
            return View();
        }
    }
}