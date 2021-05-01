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
    public class RentalRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/RentalRequests
        public ActionResult Index()
        {
            return View(db.RentalRequest.ToList());
        }

        // GET: Rent/RentalRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalRequest rentalRequest = db.RentalRequest.Find(id);
            if (rentalRequest == null)
            {
                return HttpNotFound();
            }
            PopulateAssociatedRentalsList((int)id);
            return View(rentalRequest);
        }

        // GET: Rent/RentalRequests/Create
        public ActionResult Create()
        {
            PopulateNullRentalsList();
            return View();
        }

        // POST: Rent/RentalRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalRequestID,ContactPerson,Company,RequestedTime,StartTime,EndTime,ProjectInfo," +
            "RentalCode,Accepted,ContractSigned")] RentalRequest rentalRequest, string[] selectedRentals)
        {
            if (selectedRentals != null)
            {
                rentalRequest.Rentals = new List<Rental>();
                foreach (var rental in selectedRentals)
                {
                    var rentalToAdd = db.Rentals.Find(int.Parse(rental));
                    rentalRequest.Rentals.Add(rentalToAdd);
                    rentalToAdd.RentalRequestID = rentalRequest.RentalRequestID;
                    
                }
            }

            if (ModelState.IsValid)
            {
                db.RentalRequest.Add(rentalRequest);
                foreach (var rental in rentalRequest.Rentals)
                {
                    db.Entry(rental).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalRequest);
        }

        // GET: Rent/RentalRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalRequest rentalRequest = db.RentalRequest.Find(id);
            if (rentalRequest == null)
            {
                return HttpNotFound();
            }
            PopulateNullRentalsList();
            return View(rentalRequest);
        }

        private void PopulateNullRentalsList()
        {
            var rentals = db.Rentals.ToList();
            List<Rental> nullRentals = new List<Rental>();
            foreach (Rental rental in rentals)
            {
                if (rental.RentalRequestID == null)
                {
                    nullRentals.Add(rental);
                }
            }
            ViewBag.nullRentals = nullRentals;
        }

        private void PopulateAssociatedRentalsList(int key)
        {
            var rentals = db.Rentals.ToList();
            List<Rental> associatedRentals = new List<Rental>();
            foreach (Rental rental in rentals)
            {
                if (rental.RentalRequestID == key)
                {
                    associatedRentals.Add(rental);
                }
            }
            ViewBag.associatedRentals = associatedRentals;
        }

        // POST: Rent/RentalRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalRequestID,ContactPerson,Company,RequestedTime,StartTime,EndTime,ProjectInfo,RentalCode,Accepted,ContractSigned")] RentalRequest rentalRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalRequest);
        }

        // GET: Rent/RentalRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalRequest rentalRequest = db.RentalRequest.Find(id);
            if (rentalRequest == null)
            {
                return HttpNotFound();
            }
            PopulateAssociatedRentalsList((int)id);
            return View(rentalRequest);
        }

        // POST: Rent/RentalRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalRequest rentalRequest = db.RentalRequest.Find(id);
            db.RentalRequest.Remove(rentalRequest);
            foreach (Rental rental in db.Rentals)
            {
                if (rental.RentalRequestID == rentalRequest.RentalRequestID)
                {
                    rental.RentalRequestID = null;
                }
            }
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
