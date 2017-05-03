using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reticule.Models;

namespace Reticule.Controllers
{
    public class ReserversController : Controller
    {
        private ReticuleBaseEntities db = new ReticuleBaseEntities();

        // GET: Reservers
        public ActionResult Index()
        {
            var reservers = db.Reservers.Include(r => r.Equipement_Mobile).Include(r => r.Salle);
            return View(reservers.ToList());
        }

        // GET: Reservers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserver reserver = db.Reservers.Find(id);
            if (reserver == null)
            {
                return HttpNotFound();
            }
            return View(reserver);
        }

        // GET: Reservers/Create
        public ActionResult Create()
        {
            ViewBag.EMID = new SelectList(db.Equipement_Mobile, "EMID", "NomEM");
            ViewBag.SalleID = new SelectList(db.Salles, "SalleID", "NomSalle");
            return View();
        }

        // POST: Reservers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReservation,Date2Debut,Date2Fin,SalleID,EMID")] Reserver reserver)
        {
            if (ModelState.IsValid)
            {
                db.Reservers.Add(reserver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMID = new SelectList(db.Equipement_Mobile, "EMID", "NomEM", reserver.EMID);
            ViewBag.SalleID = new SelectList(db.Salles, "SalleID", "NomSalle", reserver.SalleID);
            return View(reserver);
        }

        // GET: Reservers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserver reserver = db.Reservers.Find(id);
            if (reserver == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMID = new SelectList(db.Equipement_Mobile, "EMID", "NomEM", reserver.EMID);
            ViewBag.SalleID = new SelectList(db.Salles, "SalleID", "NomSalle", reserver.SalleID);
            return View(reserver);
        }

        // POST: Reservers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReservation,Date2Debut,Date2Fin,SalleID,EMID")] Reserver reserver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMID = new SelectList(db.Equipement_Mobile, "EMID", "NomEM", reserver.EMID);
            ViewBag.SalleID = new SelectList(db.Salles, "SalleID", "NomSalle", reserver.SalleID);
            return View(reserver);
        }

        // GET: Reservers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserver reserver = db.Reservers.Find(id);
            if (reserver == null)
            {
                return HttpNotFound();
            }
            return View(reserver);
        }

        // POST: Reservers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserver reserver = db.Reservers.Find(id);
            db.Reservers.Remove(reserver);
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
