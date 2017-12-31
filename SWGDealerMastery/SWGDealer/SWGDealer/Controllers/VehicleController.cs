using SWGDealer.Data;
using SWGDealer.Data.Interfaces;
using SWGDealer.Models.DealerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SWGDealer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {
        ISWGDealerRepo repo = SWGDealerManagerFactory.Create();

        [Route("featured")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Featured()
        {
            List<Vehicle> carReturn = repo.GetAllFeatured();

            if(carReturn==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(carReturn);
            }
        }

        [Route("specials")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Specials()
        {
            List<SalesSpecials> saleReturn = repo.GetAllSpecials();

            if(saleReturn==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(saleReturn);
            }
        }

        [Route("vehicle/{type}/{searchKey}/{minYear}/{maxYear}/{minPrice}/{maxPrice}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string type, string searchKey, int minYear, int maxYear, decimal minPrice, decimal maxPrice)
        {
            List<Vehicle> carReturn = repo.GetAllVehicles(type, searchKey, minYear, maxYear, minPrice, maxPrice);

            if (carReturn==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(carReturn);
            }
        }

        //[Route("vehicle/")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult SearchNew()
        //{
        //    throw new NotImplementedException();
        //}

        //[Route("")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult SearchUsed()
        //{
        //    throw new NotImplementedException();
        //}

        [Route("vehicle/{id}")]
        [AcceptVerbs("Get")]
        public IHttpActionResult SearchId(int id)
        {
            Vehicle carReturn = repo.GetVehicleById(id);
            if (carReturn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(carReturn);
            }
        }
    }
}
