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
            "RentalCode,Accepted,ContractSigned")] RentalRequest rentalRequest, string[] selectedRentals /*List containing associated rentals selected by user*/)
        {
            if (selectedRentals != null) //only if they clicked on some rentals to associate with the request
            {
                rentalRequest.Rentals = new List<Rental>(); 
                foreach (var rental in selectedRentals)
                {
                    // find the rental in the database and add it to the list that holds rentals associated with the request
                    var rentalToAdd = db.Rentals.Find(int.Parse(rental));
                    rentalRequest.Rentals.Add(rentalToAdd);
                    rentalToAdd.RentalRequestID = rentalRequest.RentalRequestID;
                    
                }
            }

            if (ModelState.IsValid)
            {
                // creates the rental request in db
                db.RentalRequest.Add(rentalRequest);

                // only adds foreign key to rentals table if we have any in the list. 
                if (rentalRequest.Rentals != null)
                {
                    foreach (var rental in rentalRequest.Rentals)
                    {
                        db.Entry(rental).State = EntityState.Modified;
                    }
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

            //gets null rentals
            PopulateNullRentalsList();

            //gets all associated rentals
            PopulateAssociatedRentalsList((int)id);

            //get a list of all rentals
            List<Rental> allRentals = db.Rentals.ToList();
            ViewBag.allRentals = allRentals;
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
        public ActionResult Edit([Bind(Include = "RentalRequestID,ContactPerson,Company,RequestedTime,StartTime,EndTime," +
            "ProjectInfo,RentalCode,Accepted,ContractSigned")] RentalRequest rentalRequest, string[] selectedRentals /*List containing associated rentals selected by user*/)
        {
            List<Rental> deleteRelationship = new List<Rental>(); // list of rentals that will no longer be associated with rental request
            rentalRequest.Rentals = new List<Rental>();

            // populate rentals list property of RentalRequest
            if (selectedRentals != null)
            {
                foreach (var rental in selectedRentals)
                {
                    var rentalToAdd = db.Rentals.Find(int.Parse(rental));
                    rentalRequest.Rentals.Add(rentalToAdd);
                    rentalToAdd.RentalRequestID = rentalRequest.RentalRequestID;
                }
            }

            // populate deleteRelationship list, and modify Rentals db entry
            foreach (var rental in db.Rentals.ToList())
            {
                // if a rental is found that has foreign key of request, but is not in current list of associated rentals, delete the foreign key
                if ((rental.RentalRequestID == rentalRequest.RentalRequestID && !rentalRequest.Rentals.Contains(rental)))
                {
                    rental.RentalRequestID = null;
                    deleteRelationship.Add(rental);
                }
            }

            if (ModelState.IsValid)
            {
                // save all modifications
                db.Entry(rentalRequest).State = EntityState.Modified;
                foreach (var rental in rentalRequest.Rentals)
                {
                    db.Entry(rental).State = EntityState.Modified;
                }
                foreach (var rental in deleteRelationship)
                {
                    db.Entry(rental).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //if (ModelState.IsValid)
            //{
            //    db.Entry(rentalRequest).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
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
