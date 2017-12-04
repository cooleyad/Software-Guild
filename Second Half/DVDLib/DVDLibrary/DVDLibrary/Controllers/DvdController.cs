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

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }


        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdId (int id)
        {
            Dvd returnId = repo.GetDvdById(id);

            if (returnId==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(returnId);
            }
        }

        [Route("dvds/rating/{ratingType}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult dvdRating(string ratingType)
        {
            List<Dvd> dvdFound = repo.DvdByRating(ratingType);

            if (dvdFound==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvdFound);
            }

        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult dvdTitle(string title)
        {
            List<Dvd> dvdFound = repo.DvdByTitle(title);

            if (dvdFound==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvdFound);
            }
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdYear (int releaseYear)
        {
            List<Dvd> dvdFound = repo.DvdReleaseYear(releaseYear);

            if(dvdFound==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvdFound);
            }
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DvdDirector(string directorName)
        {
            List<Dvd> dvdFound = repo.DvdByDirector(directorName);

            if(dvdFound==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvdFound);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd dvd)
        {
            repo.AddDvd(dvd);
            return Created($"dvd/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{dvd}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(Dvd dvd)
        {
            repo.EditDvd(dvd);
            return Ok();
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            repo.DeleteDvd(id);
            return Ok();
        }
    }
}
