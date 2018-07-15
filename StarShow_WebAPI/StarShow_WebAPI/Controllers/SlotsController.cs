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
    public class SlotsController : ApiController
    {
        private StarShowDBEntities db = new StarShowDBEntities();

        // GET: api/Slots
        public IQueryable<Slot> GetSlots()
        {
            return db.Slots;
        }

        // GET: api/Slots/5
        [ResponseType(typeof(Slot))]
        public IHttpActionResult GetSlot(string id)
        {
            Slot slot = db.Slots.Find(id);
            if (slot == null)
            {
                return NotFound();
            }

            return Ok(slot);
        }

        // PUT: api/Slots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSlot(string id, Slot slot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != slot.id)
            {
                return BadRequest();
            }

            db.Entry(slot).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlotExists(id))
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

        // POST: api/Slots
        [ResponseType(typeof(Slot))]
        public IHttpActionResult PostSlot(Slot slot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Slots.Add(slot);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SlotExists(slot.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = slot.id }, slot);
        }

        // DELETE: api/Slots/5
        [ResponseType(typeof(Slot))]
        public IHttpActionResult DeleteSlot(string id)
        {
            Slot slot = db.Slots.Find(id);
            if (slot == null)
            {
                return NotFound();
            }

            db.Slots.Remove(slot);
            db.SaveChanges();

            return Ok(slot);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SlotExists(string id)
        {
            return db.Slots.Count(e => e.id == id) > 0;
        }
    }
}