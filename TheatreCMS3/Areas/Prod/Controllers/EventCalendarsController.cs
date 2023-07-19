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
    public class EventCalendarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/EventCalendars
        public ActionResult Index()
        {
            return View(db.EventCalendars.ToList());
        }

        // GET: Prod/EventCalendars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCalendar eventCalendar = db.EventCalendars.Find(id);
            if (eventCalendar == null)
            {
                return HttpNotFound();
            }
            return View(eventCalendar);
        }

        // GET: Prod/EventCalendars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/EventCalendars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,ShowTitle,StartDate,EndDate,StartTime,EndTime,AllDay,TicketsAvailable,IsProduction,Description")] EventCalendar eventCalendar)
        {
            if (ModelState.IsValid)
            {
                db.EventCalendars.Add(eventCalendar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventCalendar);
        }

        // GET: Prod/EventCalendars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCalendar eventCalendar = db.EventCalendars.Find(id);
            if (eventCalendar == null)
            {
                return HttpNotFound();
            }
            return View(eventCalendar);
        }

        // POST: Prod/EventCalendars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,ShowTitle,StartDate,EndDate,StartTime,EndTime,AllDay,TicketsAvailable,IsProduction,Description")] EventCalendar eventCalendar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventCalendar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventCalendar);
        }

        // GET: Prod/EventCalendars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventCalendar eventCalendar = db.EventCalendars.Find(id);
            if (eventCalendar == null)
            {
                return HttpNotFound();
            }
            return View(eventCalendar);
        }

        // POST: Prod/EventCalendars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventCalendar eventCalendar = db.EventCalendars.Find(id);
            db.EventCalendars.Remove(eventCalendar);
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
