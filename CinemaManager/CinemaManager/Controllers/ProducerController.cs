using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaManager.Models;
using System.Data.Entity;

namespace CinemaManager.Controllers
{
    public class ProducerController : Controller
    {
        CinemaEntities db = new CinemaEntities();
        // GET: Producer
        public ActionResult Index()
        {

            return View(db.Producer.ToList());
        }

        // GET: Producer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producer/Create
        [HttpPost]
        public ActionResult Create(Producer producer)
        {
            try
            {
                // TODO: Add insert logic here
                db.Producer.Add(producer);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producer/Edit/5
        public ActionResult Edit(int id)
        {
            Producer P = db.Producer.Find(id);
            return View(P);
        }

        // POST: Producer/Edit/5
        [HttpPost]
        public ActionResult Edit(Producer P)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(P).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producer/Delete/5
        public ActionResult Delete(int id)
        {
            Producer P = db.Producer.Find(id);
            return View(P);
        }

        // POST: Producer/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed (int id)
        {
            Producer P = null;
            try
            {
                // TODO: Add delete logic here 
                P = db.Producer.Find(id);
                var movies = from m in db.Movie where m.ProducerId == id select m;
                foreach (var m in movies)
                    db.Movie.Remove(m);
                db.Producer.Remove(P);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }


}
