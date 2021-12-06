﻿using System;
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
    public class CalendarEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/CalendarEvents
        public ActionResult Index()
        {
            return View(db.CalendarEventModels.ToList());
        }

        // GET: Prod/CalendarEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEventModel calendarEventModel = db.CalendarEventModels.Find(id);
            if (calendarEventModel == null)
            {
                return HttpNotFound();
            }
            return View(calendarEventModel);
        }

        // GET: Prod/CalendarEvents/Create
        public ActionResult Create()
        {
            Productions();
            return View();
        }

        // POST: Prod/CalendarEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,Title,StartDate,EndDate,StartTime,EndTime,AllDay,TicketsAvailable,IsProduction")] CalendarEventModel calendarEventModel, int production)
        {
            if (ModelState.IsValid)
            {
                calendarEventModel.Production = db.Productions.Find(production);
                db.CalendarEventModels.Add(calendarEventModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calendarEventModel);
        }

        public void Productions()
        {
            List<Production> productions = db.Productions.GroupBy(prod => new { prod.ProductionID }).Select(i => i.FirstOrDefault()).ToList();

            var Productions = productions.Select(i => new SelectListItem
            {
                Value = i.ProductionID.ToString(),
                Text = i.Title
            });

            ViewData["Production"] = new SelectList(Productions, "Value", "Text");
        }

        // GET: Prod/CalendarEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            Productions();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEventModel calendarEventModel = db.CalendarEventModels.Find(id);
            if (calendarEventModel == null)
            {
                return HttpNotFound();
            }
            return View(calendarEventModel);
        }

        // POST: Prod/CalendarEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Title,StartDate,EndDate,StartTime,EndTime,AllDay,TicketsAvailable,IsProduction")] CalendarEventModel calendarEventModel, int production)
        {
            if (ModelState.IsValid)
            {
                calendarEventModel.Production = db.Productions.Find(production);
                db.Entry(calendarEventModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calendarEventModel);
        }

        // GET: Prod/CalendarEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEventModel calendarEventModel = db.CalendarEventModels.Find(id);
            if (calendarEventModel == null)
            {
                return HttpNotFound();
            }
            return View(calendarEventModel);
        }

        // POST: Prod/CalendarEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalendarEventModel calendarEventModel = db.CalendarEventModels.Find(id);
            db.CalendarEventModels.Remove(calendarEventModel);
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