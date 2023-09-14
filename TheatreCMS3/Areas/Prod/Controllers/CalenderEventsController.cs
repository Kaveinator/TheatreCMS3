using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class CalenderEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/CalenderEvents
        public ActionResult Index()
        {
            return View(db.CalenderEvents.ToList());
        }

        // GET: Prod/CalenderEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalenderEvent calenderEvent = db.CalenderEvents.Find(id);
            if (calenderEvent == null)
            {
                return HttpNotFound();
            }
            return View(calenderEvent);
        }

        // GET: Prod/CalenderEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/CalenderEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,StartDate,EndDate,StartTime,EndTime,AllDay,TicketsAvailable,IsProduction")] CalenderEvent calenderEvent)
        {
            if (ModelState.IsValid)
            {
                db.CalenderEvents.Add(calenderEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calenderEvent);
        }

        // GET: Prod/CalenderEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalenderEvent calenderEvent = db.CalenderEvents.Find(id);
            if (calenderEvent == null)
            {
                return HttpNotFound();
            }
            return View(calenderEvent);
        }

        // POST: Prod/CalenderEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,StartDate,EndDate,StartTime,EndTime,AllDay,TicketsAvailable,IsProduction")] CalenderEvent calenderEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calenderEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calenderEvent);
        }

        // GET: Prod/CalenderEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalenderEvent calenderEvent = db.CalenderEvents.Find(id);
            if (calenderEvent == null)
            {
                return HttpNotFound();
            }
            return View(calenderEvent);
        }

        // POST: Prod/CalenderEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalenderEvent calenderEvent = db.CalenderEvents.Find(id);
            db.CalenderEvents.Remove(calenderEvent);
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
