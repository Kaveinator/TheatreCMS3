using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Models;
using PagedList;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/Productions

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            //pagination
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            //search for specific record
            var productions = from p in db.Productions select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                productions = productions.Where(p => p.Title.Contains(searchString));
            }

            productions = productions.OrderBy(p => p.OpeningDay);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(productions.ToPagedList(pageNumber, pageSize));
        }

        // GET: Prod/Productions/Details/5
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

        // GET: Prod/Productions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/Productions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductionId,Title,Description,Playwright,Runtime,OpeningDay,ClosingDay,ShowTimeEve,ShowTimeMat,Season,IsWorldPremiere,TicketLink,IsCurrentlyShowing")] Productions productions)
        {
            if (ModelState.IsValid)
            {
                db.Productions.Add(productions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productions);
        }

        // GET: Prod/Productions/Edit/5
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

        // POST: Prod/Productions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionId,Title,Description,Playwright,Runtime,OpeningDay,ClosingDay,ShowTimeEve,ShowTimeMat,Season,IsWorldPremiere,TicketLink,IsCurrentlyShowing")] Productions productions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productions);
        }

        // GET: Prod/Productions/Delete/5
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

        // POST: Prod/Productions/Delete/5
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
