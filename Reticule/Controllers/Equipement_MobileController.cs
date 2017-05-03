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
    public class Equipement_MobileController : Controller
    {
        private ReticuleBaseEntities db = new ReticuleBaseEntities();

        // GET: Equipement_Mobile
        public ActionResult Index()
        {
            return View(db.Equipement_Mobile.ToList());
        }

        // GET: Equipement_Mobile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipement_Mobile equipement_Mobile = db.Equipement_Mobile.Find(id);
            if (equipement_Mobile == null)
            {
                return HttpNotFound();
            }
            return View(equipement_Mobile);
        }

        // GET: Equipement_Mobile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipement_Mobile/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMID,NomEM,TypeEM")] Equipement_Mobile equipement_Mobile)
        {
            if (ModelState.IsValid)
            {
                db.Equipement_Mobile.Add(equipement_Mobile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipement_Mobile);
        }

        // GET: Equipement_Mobile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipement_Mobile equipement_Mobile = db.Equipement_Mobile.Find(id);
            if (equipement_Mobile == null)
            {
                return HttpNotFound();
            }
            return View(equipement_Mobile);
        }

        // POST: Equipement_Mobile/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMID,NomEM,TypeEM")] Equipement_Mobile equipement_Mobile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipement_Mobile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipement_Mobile);
        }

        // GET: Equipement_Mobile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipement_Mobile equipement_Mobile = db.Equipement_Mobile.Find(id);
            if (equipement_Mobile == null)
            {
                return HttpNotFound();
            }
            return View(equipement_Mobile);
        }

        // POST: Equipement_Mobile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipement_Mobile equipement_Mobile = db.Equipement_Mobile.Find(id);
            db.Equipement_Mobile.Remove(equipement_Mobile);
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
