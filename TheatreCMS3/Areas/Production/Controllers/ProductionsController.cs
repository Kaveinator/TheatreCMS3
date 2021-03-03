using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Production.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Production.Controllers
{
    public class ProductionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Production/Productions
        public ActionResult Index()
        {
            return View(db.Productions.ToList());
        }

        // GET: Production/Productions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productions productions = db.Productions.Find(id);
            if (productions == null)
            {
                return HttpNotFound();
            }
            return View(productions);
        }

        // GET: Production/Productions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Production/Productions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductionId,Title,Playwright,Description,OpeningDay,ClosingDay,"/*Default,*/+"ShowtimeEve,ShowtimeMat,TicketLink,Season,IsCurrent")] Productions productions)
        {
            if (ModelState.IsValid)
            {
                Productions production = db.Productions.Add(productions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productions);
        }

        // GET: Production/Productions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productions productions = db.Productions.Find(id);
            if (productions == null)
            {
                return HttpNotFound();
            }
            return View(productions);
        }

        // POST: Production/Productions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionId,Title,Playwright,Description,OpeningDay,ClosingDay,Default,ShowtimeEve,ShowtimeMat,TicketLink,Season,IsCurrent")] Productions productions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productions);
        }

        // GET: Production/Productions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productions productions = db.Productions.Find(id);
            if (productions == null)
            {
                return HttpNotFound();
            }
            return View(productions);
        }

        // POST: Production/Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productions productions = db.Productions.Find(id);
            db.Productions.Remove(productions);
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
