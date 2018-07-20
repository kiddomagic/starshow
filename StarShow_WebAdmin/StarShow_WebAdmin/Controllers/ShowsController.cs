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
    public class ShowsController : Controller
    {
        private StarShowDBEntities db = new StarShowDBEntities();
        ShowRepository showRepository = new ShowRepository();

        // GET: Shows
        public ActionResult Index()
        {
            return View(showRepository.GetShows());
        }

        // GET: Shows/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = showRepository.GetShow(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,description,releaseDate,status")] Show show)
        {
            if (ModelState.IsValid)
            {
                showRepository.AddShow(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = showRepository.GetShow(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,description,releaseDate,status")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = showRepository.GetShow(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {            
            showRepository.DeleteShow(id);
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
