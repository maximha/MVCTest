using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class WorkoutsController : Controller
    {
        private social_workout_app_dbEntities db = new social_workout_app_dbEntities();

        //
        // GET: /Workouts/

        public ActionResult Index()
        {
            var workouts1 = db.workouts1.Include(w => w.user);
            return View(workouts1.ToList());
        }

        //
        // GET: /Workouts/Details/5

        public ActionResult Details(string id = null)
        {
            workout1 workout1 = db.workouts1.Find(id);
            if (workout1 == null)
            {
                return HttpNotFound();
            }
            return View(workout1);
        }

        //
        // GET: /Workouts/Create

        public ActionResult Create()
        {
            ViewBag.userName = new SelectList(db.users, "userName", "firstName");
            return View();
        }

        //
        // POST: /Workouts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(workout1 workout1)
        {
            if (ModelState.IsValid)
            {
                db.workouts1.Add(workout1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userName = new SelectList(db.users, "userName", "firstName", workout1.userName);
            return View(workout1);
        }

        //
        // GET: /Workouts/Edit/5

        public ActionResult Edit(string id = null)
        {
            workout1 workout1 = db.workouts1.Find(id);
            if (workout1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.userName = new SelectList(db.users, "userName", "firstName", workout1.userName);
            return View(workout1);
        }

        //
        // POST: /Workouts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(workout1 workout1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workout1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userName = new SelectList(db.users, "userName", "firstName", workout1.userName);
            return View(workout1);
        }

        //
        // GET: /Workouts/Delete/5

        public ActionResult Delete(string id = null)
        {
            workout1 workout1 = db.workouts1.Find(id);
            if (workout1 == null)
            {
                return HttpNotFound();
            }
            return View(workout1);
        }

        //
        // POST: /Workouts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            workout1 workout1 = db.workouts1.Find(id);
            db.workouts1.Remove(workout1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}