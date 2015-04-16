using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class WorkoutController : Controller
    {
        private social_workout_app_dbEntities db = new social_workout_app_dbEntities();

        //
        // GET: /Workout/

        public ActionResult Index()
        {
            var workouts = db.workouts.Include(w => w.workout1);
            return View(workouts.ToList());
        }

        //
        // GET: /Workout/Details/5

        public ActionResult Details(string id = null)
        {
            workout workout = db.workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        //
        // GET: /Workout/Create

        public ActionResult Create()
        {
            ViewBag.workoutName = new SelectList(db.workouts1, "workoutName", "userName");
            return View();
        }

        //
        // POST: /Workout/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(workout workout)
        {
            if (ModelState.IsValid)
            {
                db.workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.workoutName = new SelectList(db.workouts1, "workoutName", "userName", workout.workoutName);
            return View(workout);
        }

        //
        // GET: /Workout/Edit/5

        public ActionResult Edit(string id = null)
        {
            workout workout = db.workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            ViewBag.workoutName = new SelectList(db.workouts1, "workoutName", "userName", workout.workoutName);
            return View(workout);
        }

        //
        // POST: /Workout/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.workoutName = new SelectList(db.workouts1, "workoutName", "userName", workout.workoutName);
            return View(workout);
        }

        //
        // GET: /Workout/Delete/5

        public ActionResult Delete(string id = null)
        {
            workout workout = db.workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        //
        // POST: /Workout/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            workout workout = db.workouts.Find(id);
            db.workouts.Remove(workout);
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