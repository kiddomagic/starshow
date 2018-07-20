using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarShow_WebAdmin.Models;
using StarShow_WebAdmin.Models.Repositories;

namespace StarShow_WebAdmin.Controllers
{
    public class SlotsController : Controller
    {
        private StarShowDBEntities db = new StarShowDBEntities();
        SlotRepository sr = new SlotRepository();

        // GET: Slots
        public ActionResult Index()
        {
            var slots = db.Slots.Include(s => s.Location).Include(s => s.Show);
            return View(slots.ToList());
        }

        // GET: Slots/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slot slot = sr.GetSlot(id);
            if (slot == null)
            {
                return HttpNotFound();
            }
            return View(slot);
        }

        // GET: Slots/Create
        public ActionResult Create()
        {
            ViewBag.locationId = new SelectList(db.Locations, "id", "name");
            ViewBag.showId = new SelectList(db.Shows, "id", "title");
            return View();
        }

        // POST: Slots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date,startTime,endTime,locationId,showId,guest")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                sr.AddSlot(slot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.locationId = new SelectList(db.Locations, "id", "name", slot.locationId);
            ViewBag.showId = new SelectList(db.Shows, "id", "title", slot.showId);
            return View(slot);
        }

        // GET: Slots/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slot slot = sr.GetSlot(id);
            if (slot == null)
            {
                return HttpNotFound();
            }
            ViewBag.locationId = new SelectList(db.Locations, "id", "name", slot.locationId);
            ViewBag.showId = new SelectList(db.Shows, "id", "title", slot.showId);
            return View(slot);
        }

        // POST: Slots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date,startTime,endTime,locationId,showId,guest")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.locationId = new SelectList(db.Locations, "id", "name", slot.locationId);
            ViewBag.showId = new SelectList(db.Shows, "id", "title", slot.showId);
            return View(slot);
        }

        // GET: Slots/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slot slot = sr.GetSlot(id);
            if (slot == null)
            {
                return HttpNotFound();
            }
            return View(slot);
        }

        // POST: Slots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sr.DeleteSlot(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
