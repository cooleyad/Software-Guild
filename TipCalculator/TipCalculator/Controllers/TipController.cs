using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class TipController : Controller
    {
        [HttpGet]
        public ActionResult Tip()
        {
            TipModel m = new TipModel();

            return View(m);
        }


        [HttpPost]
        public ActionResult Tip(TipModel model)
        {

            return View(model);
        }

    }
}