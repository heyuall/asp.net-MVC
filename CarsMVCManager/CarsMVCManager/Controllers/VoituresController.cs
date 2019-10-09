using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsMVCManager.Models;

namespace CarsMVCManager.Controllers
{
    public class VoituresController : Controller
    {
        private CarsModelContainer db = new CarsModelContainer();

        // GET: Voitures
        public ActionResult Index()
        {
            var voitureSet = db.VoitureSet.Include(v => v.Proprietaire);
            return View(voitureSet.ToList());
        }

        // GET: Voitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.VoitureSet.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: Voitures/Create
        public ActionResult Create()
        {
            ViewBag.ProprietaireId = new SelectList(db.ProprietaireSet, "Id", "Nom");
            return View();
        }

        // POST: Voitures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,PFiscale,Marque,Modele,Carburant,Matricule,Couleur,ProprietaireId")] Voiture voiture)
        {
            if (voiture.Marque == 0)
            {
                ModelState.AddModelError("Marque", "Veuillez choisir une marque");
            }
            if (ModelState.IsValid)
            {
                db.VoitureSet.Add(voiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProprietaireId = new SelectList(db.ProprietaireSet, "Id", "Nom", voiture.ProprietaireId);
            return View(voiture);
        }

        // GET: Voitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.VoitureSet.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProprietaireId = new SelectList(db.ProprietaireSet, "Id", "Nom", voiture.ProprietaireId);
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,PFiscale,Marque,Modele,Carburant,Matricule,Couleur,ProprietaireId")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProprietaireId = new SelectList(db.ProprietaireSet, "Id", "Nom", voiture.ProprietaireId);
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.VoitureSet.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voiture voiture = db.VoitureSet.Find(id);
            db.VoitureSet.Remove(voiture);
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
