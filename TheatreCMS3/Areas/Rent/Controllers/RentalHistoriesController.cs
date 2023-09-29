using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Rent.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Controllers
{
    public class RentalHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/RentalHistories
        public ActionResult Index()
        {
            return View(db.RentalHistories.ToList());
        }

        public ActionResult testPartial(string sortOrder)
        {
            var rents = from r in db.RentalHistories
                           select r;

            switch (sortOrder)
            {
                case "name_desc":
                    rents = rents.OrderByDescending(r => r.Rental);
                    break;
                case "name_asc":
                    rents = rents.OrderBy(r => r.Rental);
                    break;
                case "damage_desc":
                    rents = rents.OrderByDescending(r => r.RentalDamaged);
                    break;
                case "damage_asc":
                    rents = rents.OrderBy(r => r.RentalDamaged);
                    break;
               
            }
            return PartialView(rents.ToList());
        }

          
        // GET: Rent/RentalHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalHistory rentalHistory = db.RentalHistories.Find(id);
            if (rentalHistory == null)
            {
                return HttpNotFound();
            }
            return View(rentalHistory);
        }

        // GET: Rent/RentalHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rent/RentalHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HistoryManagerAttribute]
        public ActionResult Create([Bind(Include = "RentalHistoryId,RentalDamaged,DamagesIncurred,Rental")] RentalHistory rentalHistory)
        {
            if (ModelState.IsValid)
            {
                db.RentalHistories.Add(rentalHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalHistory);
        }

        // GET: Rent/RentalHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalHistory rentalHistory = db.RentalHistories.Find(id);
            if (rentalHistory == null)
            {
                return HttpNotFound();
            }
            return View(rentalHistory);
        }
        [HistoryManagerAttribute]
        // POST: Rent/RentalHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalHistoryId,RentalDamaged,DamagesIncurred,Rental")] RentalHistory rentalHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalHistory);
        }

        // GET: Rent/RentalHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalHistory rentalHistory = db.RentalHistories.Find(id);
            if (rentalHistory == null)
            {
                return HttpNotFound();
            }
            return View(rentalHistory);
        }

        // POST: Rent/RentalHistories/Delete/5
        [HistoryManagerAttribute]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalHistory rentalHistory = db.RentalHistories.Find(id);
            db.RentalHistories.Remove(rentalHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AccessDenied()
        {
           
            return View();
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
