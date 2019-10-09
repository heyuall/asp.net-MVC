using CinemaManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaManager.Controllers
{
    public class MovieController : Controller
    {
        CinemaEntities db = new CinemaEntities();
        // GET: Movie
        public ActionResult Index()
        {
            return View(db.Movie.ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movie M)
        {
            try
            {
                // TODO: Add insert logic here
                db.Movie.Add(M);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            Movie M = db.Movie.Find(id);
            return View(M);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie M)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(M).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {Movie M = db.Movie.Find(id);
            return View(M);
         
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {  
            { Movie M = null;
                try
            {
                M = db.Movie.Find(id);
                db.Movie.Remove(M);
                db.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
