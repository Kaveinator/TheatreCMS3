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

namespace TheatreCMS3.Areas.Rent
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/Rentals
        public ActionResult Index()
        {
            return View(db.Rentals.ToList());
        }

        // GET: Rent/Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rent/Rentals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rent/Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages")] Rental rental, int? PurchasePrice, bool ChokingHazard, bool SuffocationHazard,
            int? RoomNumber, int? SquareFootage, int? MaxOccupancy)
        {
            if (PurchasePrice > 0)
            {
                RentalEquipment rentalEquipment = new RentalEquipment();
                rentalEquipment.RentalName = rental.RentalName;
                rentalEquipment.RentalCost = rental.RentalCost;
                rentalEquipment.FlawsAndDamages = rental.FlawsAndDamages;
                rentalEquipment.ChokingHazard = Convert.ToBoolean(ChokingHazard);
                rentalEquipment.SuffocationHazard = Convert.ToBoolean(SuffocationHazard);
                rentalEquipment.PurchasePrice = Convert.ToInt32(PurchasePrice);

                db.Rentals.Add(rentalEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else if (RoomNumber > 0)
            {
                RentalRoom rentalRoom = new RentalRoom();
                rentalRoom.RentalName = rental.RentalName;
                rentalRoom.RentalCost = rental.RentalCost;
                rentalRoom.FlawsAndDamages = rental.FlawsAndDamages;
                rentalRoom.RoomNumber = Convert.ToInt32(RoomNumber);
                rentalRoom.SquareFootage = Convert.ToInt32(SquareFootage);
                rentalRoom.MaxOccupancy = Convert.ToInt32(MaxOccupancy);

                db.Rentals.Add(rentalRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else if (ModelState.IsValid)
            {
                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rental);
        }

        // GET: Rent/Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rent/Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages")] Rental rental, int? PurchasePrice, bool? ChokingHazard, bool? SuffocationHazard,
            int? RoomNumber, int? SquareFootage, int? MaxOccupancy)
        {
            if (PurchasePrice > 0)
            {
                
                RentalEquipment rentalEquipment = new RentalEquipment();
                rentalEquipment.RentalId = rental.RentalId;

                rentalEquipment.RentalName = rental.RentalName;
                rentalEquipment.RentalCost = rental.RentalCost;
                rentalEquipment.FlawsAndDamages = rental.FlawsAndDamages;
                rentalEquipment.ChokingHazard = Convert.ToBoolean(ChokingHazard);
                rentalEquipment.SuffocationHazard = Convert.ToBoolean(SuffocationHazard);
                rentalEquipment.PurchasePrice = Convert.ToInt32(PurchasePrice);

                db.Entry(rentalEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (RoomNumber > 0)
            {
                RentalRoom rentalRoom = new RentalRoom();
                rentalRoom.RentalId = rental.RentalId;

                rentalRoom.RentalName = rental.RentalName;
                rentalRoom.RentalCost = rental.RentalCost;
                rentalRoom.FlawsAndDamages = rental.FlawsAndDamages;
                rentalRoom.RoomNumber = Convert.ToInt32(RoomNumber);
                rentalRoom.SquareFootage = Convert.ToInt32(SquareFootage);
                rentalRoom.MaxOccupancy = Convert.ToInt32(MaxOccupancy);

                db.Entry(rentalRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Entry(rental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental);
        }

        // GET: Rent/Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // POST: Rent/Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental rental = db.Rentals.Find(id);
            db.Rentals.Remove(rental);
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
