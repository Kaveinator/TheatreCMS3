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
    public class CalenderEventModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/CalenderEventModels
        public ActionResult Index()
        {
            return View(db.calenderEventModels.ToList());
        }

        // GET: Prod/CalenderEventModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalenderEventModels calenderEventModels = db.calenderEventModels.Find(id);
            if (calenderEventModels == null)
            {
                return HttpNotFound();
            }
            return View(calenderEventModels);
        }

        // GET: Prod/CalenderEventModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/CalenderEventModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,StartDate,EndDate,StartTime,EndTime,AllDay,TicketsAvailable,IsProduction")] CalenderEventModels calenderEventModels)
        {
            if (ModelState.IsValid)
            {
                db.calenderEventModels.Add(calenderEventModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calenderEventModels);
        }

        // GET: Prod/CalenderEventModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalenderEventModels calenderEventModels = db.calenderEventModels.Find(id);
            if (calenderEventModels == null)
            {
                return HttpNotFound();
            }
            return View(calenderEventModels);
        }

        // POST: Prod/CalenderEventModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,StartDate,EndDate,StartTime,EndTime,AllDay,TicketsAvailable,IsProduction")] CalenderEventModels calenderEventModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calenderEventModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calenderEventModels);
        }

        // GET: Prod/CalenderEventModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalenderEventModels calenderEventModels = db.calenderEventModels.Find(id);
            if (calenderEventModels == null)
            {
                return HttpNotFound();
            }
            return View(calenderEventModels);
        }

        // POST: Prod/CalenderEventModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalenderEventModels calenderEventModels = db.calenderEventModels.Find(id);
            db.calenderEventModels.Remove(calenderEventModels);
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
