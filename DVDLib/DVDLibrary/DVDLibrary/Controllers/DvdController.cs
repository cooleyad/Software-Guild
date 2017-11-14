using DVDLibrary.Data;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibrary.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class DvdController : ApiController
    {
        IDvdRepository repo = DvdRepoFactory.Create();

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdId (int id)
        {
            return Ok(repo.GetDvdById(id));
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Dvds()
        {
            return Ok(repo.GetAll());
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdTitle(string title)
        {
            return Ok(repo.DvdByTitle(title));
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdYear (int dvdYear)
        {
            return Ok(repo.DvdReleaseYear(dvdYear));
        }

        [Route("/dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdDirector(string director)
        {
            return Ok(repo.DvdByDirector(director));
        }


    }
}
