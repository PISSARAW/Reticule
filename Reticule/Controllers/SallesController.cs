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
    public class SallesController : Controller
    {
        private ReticuleBaseEntities db = new ReticuleBaseEntities();

        // GET: Salles
        public ActionResult Index()
        {
            var salles = db.Salles.Include(s => s.Equipement_Fixe).Include(s => s.Equipement_Mobile);
            return View(salles.ToList());
        }

        // GET: Salles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = db.Salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // GET: Salles/Create
        public ActionResult Create()
        {
            ViewBag.EFID = new SelectList(db.Equipement_Fixe, "EFID", "NomEF");
            ViewBag.EMID = new SelectList(db.Equipement_Mobile, "EMID", "NomEM");
            return View();
        }

        // POST: Salles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalleID,NomSalle,Batiment,Etage,EMID,EFID")] Salle salle)
        {
            if (ModelState.IsValid)
            {
                db.Salles.Add(salle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EFID = new SelectList(db.Equipement_Fixe, "EFID", "NomEF", salle.EFID);
            ViewBag.EMID = new SelectList(db.Equipement_Mobile, "EMID", "NomEM", salle.EMID);
            return View(salle);
        }

        // GET: Salles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = db.Salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            ViewBag.EFID = new SelectList(db.Equipement_Fixe, "EFID", "NomEF", salle.EFID);
            ViewBag.EMID = new SelectList(db.Equipement_Mobile, "EMID", "NomEM", salle.EMID);
            return View(salle);
        }

        // POST: Salles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalleID,NomSalle,Batiment,Etage,EMID,EFID")] Salle salle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EFID = new SelectList(db.Equipement_Fixe, "EFID", "NomEF", salle.EFID);
            ViewBag.EMID = new SelectList(db.Equipement_Mobile, "EMID", "NomEM", salle.EMID);
            return View(salle);
        }

        // GET: Salles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salle salle = db.Salles.Find(id);
            if (salle == null)
            {
                return HttpNotFound();
            }
            return View(salle);
        }

        // POST: Salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salle salle = db.Salles.Find(id);
            db.Salles.Remove(salle);
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
