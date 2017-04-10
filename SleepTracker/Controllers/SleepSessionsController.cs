using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SleepTracker.Models;

namespace SleepTracker.Controllers
{
    public class SleepSessionsController : Controller
    {
        private SleepTrackerContext db = new SleepTrackerContext();

        // GET: SleepSessions
        public ActionResult Index()
        {
            var sleepSessions = db.SleepSessions.Include(s => s.TypeOfSleep);
            return View(sleepSessions.ToList());
        }

        // GET: SleepSessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SleepSession sleepSession = db.SleepSessions.Find(id);
            if (sleepSession == null)
            {
                return HttpNotFound();
            }
            return View(sleepSession);
        }

        // GET: SleepSessions/Create
        public ActionResult Create()
        {
            ViewBag.SleepTypeID = new SelectList(db.SleepTypes, "SleepTypeID", "Description");
            return View();
        }

        // POST: SleepSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SleepSessionID,StartTime,EndTime,SleepTypeID")] SleepSession sleepSession)
        {
            if (ModelState.IsValid)
            {
                db.SleepSessions.Add(sleepSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SleepTypeID = new SelectList(db.SleepTypes, "SleepTypeID", "Description", sleepSession.SleepTypeID);
            return View(sleepSession);
        }

        // GET: SleepSessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SleepSession sleepSession = db.SleepSessions.Find(id);
            if (sleepSession == null)
            {
                return HttpNotFound();
            }
            ViewBag.SleepTypeID = new SelectList(db.SleepTypes, "SleepTypeID", "Description", sleepSession.SleepTypeID);
            return View(sleepSession);
        }

        // POST: SleepSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SleepSessionID,StartTime,EndTime,SleepTypeID")] SleepSession sleepSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sleepSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SleepTypeID = new SelectList(db.SleepTypes, "SleepTypeID", "Description", sleepSession.SleepTypeID);
            return View(sleepSession);
        }

        // GET: SleepSessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SleepSession sleepSession = db.SleepSessions.Find(id);
            if (sleepSession == null)
            {
                return HttpNotFound();
            }
            return View(sleepSession);
        }

        // POST: SleepSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SleepSession sleepSession = db.SleepSessions.Find(id);
            db.SleepSessions.Remove(sleepSession);
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
