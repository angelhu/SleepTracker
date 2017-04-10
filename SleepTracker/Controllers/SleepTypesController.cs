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
    public class SleepTypesController : Controller
    {
        private SleepTrackerContext db = new SleepTrackerContext();

        // GET: SleepTypes
        public ActionResult Index()
        {
            return View(db.SleepTypes.ToList());
        }

        // GET: SleepTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SleepType sleepType = db.SleepTypes.Find(id);
            if (sleepType == null)
            {
                return HttpNotFound();
            }
            return View(sleepType);
        }

        // GET: SleepTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SleepTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SleepTypeID,Description")] SleepType sleepType)
        {
            if (ModelState.IsValid)
            {
                db.SleepTypes.Add(sleepType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sleepType);
        }

        // GET: SleepTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SleepType sleepType = db.SleepTypes.Find(id);
            if (sleepType == null)
            {
                return HttpNotFound();
            }
            return View(sleepType);
        }

        // POST: SleepTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SleepTypeID,Description")] SleepType sleepType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sleepType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sleepType);
        }

        // GET: SleepTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SleepType sleepType = db.SleepTypes.Find(id);
            if (sleepType == null)
            {
                return HttpNotFound();
            }
            return View(sleepType);
        }

        // POST: SleepTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SleepType sleepType = db.SleepTypes.Find(id);
            db.SleepTypes.Remove(sleepType);
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
