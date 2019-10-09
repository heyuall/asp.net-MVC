using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsMVCManager.Models;
using PagedList;

namespace CarsMVCManager.Controllers
{
    public class ProprietairesController : Controller
    {
        private CarsModelContainer db = new CarsModelContainer();

        // GET: Proprietaires
        public ActionResult Index(int id)
        {
            return View(db.ProprietaireSet.ToPagedList(id,3));
        }

        // GET: Proprietaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = db.ProprietaireSet.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // GET: Proprietaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proprietaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Numpermis,Contact")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                db.ProprietaireSet.Add(proprietaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proprietaire);
        }

        // GET: Proprietaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = db.ProprietaireSet.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Numpermis,Contact")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprietaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proprietaire);
        }

        // GET: Proprietaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = db.ProprietaireSet.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proprietaire proprietaire = db.ProprietaireSet.Find(id);
            db.ProprietaireSet.Remove(proprietaire);
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
