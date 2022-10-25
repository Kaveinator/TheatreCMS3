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
using PagedList;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class ProductionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/Productions
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            /* Providing views with a sort order or a parameter (defined further down) via ViewBag */
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_ascen" : "";
            /* For  */
            if (searchString != null)
            {
                /* Reset page to 1 incase search string changed during paging */
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            /* Providing view with current filter string.
            * VALUE INCLUDED IN PAGING LINK TO MAINTAIN FILTER SETTING DURING PAGING */
            ViewBag.CurrentFilter = searchString;

            var productions = from s in db.Productions
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                
                productions = productions.Where(s => s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_ascen":
                    productions = productions.OrderBy(s => s.Title);
                    break;
                default:
                    productions = productions.OrderBy(s => s.ProductionID);
                    break;
            }

            int pageSize = 2;
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
            Production production = db.Productions.Find(id);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
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
        public ActionResult Create([Bind(Include = "ProductionID,Title,Description,Playwright,Runtime,OpeningDay,ClosingDay,ShowTimeEve,ShowTimeMat,Season,IsWorldPremiere,TicketLink,isCurrentlyShowing")] Production production)
        {
            if (ModelState.IsValid)
            {
                db.Productions.Add(production);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(production);
        }

        // GET: Prod/Productions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production production = db.Productions.Find(id);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
        }

        // POST: Prod/Productions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionID,Title,Description,Playwright,Runtime,OpeningDay,ClosingDay,ShowTimeEve,ShowTimeMat,Season,IsWorldPremiere,TicketLink,isCurrentlyShowing")] Production production)
        {
            if (ModelState.IsValid)
            {
                db.Entry(production).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(production);
        }

        // GET: Prod/Productions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Production production = db.Productions.Find(id);
            if (production == null)
            {
                return HttpNotFound();
            }
            return View(production);
        }

        // POST: Prod/Productions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Production production = db.Productions.Find(id);
            db.Productions.Remove(production);
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
