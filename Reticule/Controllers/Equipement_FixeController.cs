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
    public class Equipement_FixeController : Controller
    {
        private ReticuleBaseEntities db = new ReticuleBaseEntities();

        // GET: Equipement_Fixe
        public ActionResult Index()
        {
            return View(db.Equipement_Fixe.ToList());
        }

        // GET: Equipement_Fixe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipement_Fixe equipement_Fixe = db.Equipement_Fixe.Find(id);
            if (equipement_Fixe == null)
            {
                return HttpNotFound();
            }
            return View(equipement_Fixe);
        }

        // GET: Equipement_Fixe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipement_Fixe/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EFID,NomEF,TypeEM")] Equipement_Fixe equipement_Fixe)
        {
            if (ModelState.IsValid)
            {
                db.Equipement_Fixe.Add(equipement_Fixe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipement_Fixe);
        }

        // GET: Equipement_Fixe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipement_Fixe equipement_Fixe = db.Equipement_Fixe.Find(id);
            if (equipement_Fixe == null)
            {
                return HttpNotFound();
            }
            return View(equipement_Fixe);
        }

        // POST: Equipement_Fixe/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EFID,NomEF,TypeEM")] Equipement_Fixe equipement_Fixe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipement_Fixe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipement_Fixe);
        }

        // GET: Equipement_Fixe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipement_Fixe equipement_Fixe = db.Equipement_Fixe.Find(id);
            if (equipement_Fixe == null)
            {
                return HttpNotFound();
            }
            return View(equipement_Fixe);
        }

        // POST: Equipement_Fixe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipement_Fixe equipement_Fixe = db.Equipement_Fixe.Find(id);
            db.Equipement_Fixe.Remove(equipement_Fixe);
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
