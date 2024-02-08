using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.DAL;
using TheatreCMS3.Areas.Rent.Models;

namespace TheatreCMS3.Areas.Rent.Controllers
{
    public class RentalHistoriesController : Controller
    {
        private RentalHistoryContext db = new RentalHistoryContext(); //a class variable has been automatically created that instantiates a database context object

        // GET: RentalHistories
        public ActionResult Index() //the index action method gets a rental history list
        {
            return View(db.RentalHistories.OrderByDescending(item => item.RentalHistoryId).ToList());

        }


        // GET: RentalHistories/Details/5
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


        // GET: RentalHistories/Create
        [HistoryManager.HistoryManagerAuthorize(Roles = "HistoryManager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentalHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HistoryManager.HistoryManagerAuthorize(Roles = "HistoryManager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalHistoryId,RentalDamaged,DamagesIncurred,Rental,DateCreated")] RentalHistory rentalHistory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.RentalHistories.Add(rentalHistory);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, contact your system administrator.");
            }
            return View(rentalHistory);
        }

        // GET: RentalHistories/Edit/5
        [HistoryManager.HistoryManagerAuthorize(Roles = "HistoryManager")]
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

        [HistoryManager.HistoryManagerAuthorize(Roles = "HistoryManager")]
        // POST: RentalHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalHistoryId,RentalDamaged,DamagesIncurred,Rental")] RentalHistory rentalHistory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(rentalHistory).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, contact your system administrator.");
                }
            }
            return View(rentalHistory);
        }

        // GET: RentalHistories/Delete/5
        [HistoryManager.HistoryManagerAuthorize(Roles = "HistoryManager")]
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists, contact your system administrator.";
            }
            RentalHistory rentalHistory = db.RentalHistories.Find(id);
            if (rentalHistory == null)
            {
                return HttpNotFound();
            }
            return View(rentalHistory);
        }

        // POST: RentalHistories/Delete/5
        [HistoryManager.HistoryManagerAuthorize(Roles = "HistoryManager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                RentalHistory rentalHistory = db.RentalHistories.Find(id);
                db.RentalHistories.Remove(rentalHistory);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult SortByDamaged()
        {
            var sortedRentals = db.RentalHistories.Where(r => r.RentalDamaged).ToList();
            return PartialView("_RentalHistoriesPartial", sortedRentals);
        }
        public ActionResult SortByUndamaged()
        {
            var sortedRentals = db.RentalHistories.Where(r => !r.RentalDamaged).ToList();
            return PartialView("_RentalHistoriesPartial", sortedRentals);
        }
        public ActionResult SortByAZ()
        {
            var sortedRentals = db.RentalHistories.OrderBy(r => r.Rental).ToList();
            return PartialView("_RentalHistoriesPartial", sortedRentals);
        }
        public ActionResult SortByZA()
        {
            var sortedRentals = db.RentalHistories.OrderByDescending(r => r.Rental).ToList();
            return PartialView("_RentalHistoriesPartial", sortedRentals);
        }

        public ActionResult NoSorting()
        {
            var sortedRentals = db.RentalHistories.OrderByDescending(item => item.RentalHistoryId).ToList();
            return PartialView("_RentalHistoriesPartial", sortedRentals);
        }
        protected override void Dispose(bool disposing) //this closes database connection and frees up resources
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
