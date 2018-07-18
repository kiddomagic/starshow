using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarShow_WebAdmin.Models;

namespace StarShow_WebAdmin.Controllers
{
    public class SlotsController : Controller
    {
        private StarShowDBEntities db = new StarShowDBEntities();

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
            Slot slot = db.Slots.Find(id);
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
                db.Slots.Add(slot);
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
            Slot slot = db.Slots.Find(id);
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
            Slot slot = db.Slots.Find(id);
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
            Slot slot = db.Slots.Find(id);
            db.Slots.Remove(slot);
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
