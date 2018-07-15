using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StarShow_WebAPI.Models.Entities;

namespace StarShow_WebAPI.Controllers
{
    public class ShowsController : ApiController
    {
        private StarShowDBEntities db = new StarShowDBEntities();

        // GET: api/Shows
        public IQueryable<Show> GetShows()
        {
            return db.Shows;
        }

        // GET: api/Shows/5
        [ResponseType(typeof(Show))]
        public IHttpActionResult GetShow(string id)
        {
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return NotFound();
            }

            return Ok(show);
        }

        // PUT: api/Shows/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShow(string id, Show show)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != show.id)
            {
                return BadRequest();
            }

            db.Entry(show).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Shows
        [ResponseType(typeof(Show))]
        public IHttpActionResult PostShow(Show show)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shows.Add(show);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ShowExists(show.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = show.id }, show);
        }

        // DELETE: api/Shows/5
        [ResponseType(typeof(Show))]
        public IHttpActionResult DeleteShow(string id)
        {
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return NotFound();
            }

            db.Shows.Remove(show);
            db.SaveChanges();

            return Ok(show);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShowExists(string id)
        {
            return db.Shows.Count(e => e.id == id) > 0;
        }
    }
}