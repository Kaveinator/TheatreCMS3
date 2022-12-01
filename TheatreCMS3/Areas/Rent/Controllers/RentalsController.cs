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
        public ActionResult Create(
            [Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages,ChokingHazard,SuffocationHazard,PurchasePrice,RoomNumber,SquareFootage,MaxOccupancy")] Rental rental,
            RentalEquipment rentalEquipment,
            RentalRoom rentalRoom)
        {
            if (rentalEquipment.PurchasePrice != null)
            {
                var rentalEquipments = new RentalEquipment
                {
                    //RentalId = rental.RentalId,
                    RentalName = rental.RentalName,
                    RentalCost = rental.RentalCost,
                    FlawsAndDamages = rental.FlawsAndDamages,
                    ChokingHazard = rentalEquipment.ChokingHazard,
                    SuffocationHazard = rentalEquipment.SuffocationHazard,
                    PurchasePrice = rentalEquipment.PurchasePrice
            };

                db.Rentals.Add(rentalEquipments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (rentalRoom.RoomNumber != null)
            {
                var rentalRooms = new RentalRoom
                {
                    //RentalId = rental.RentalId,
                    RentalName = rental.RentalName,
                    RentalCost = rental.RentalCost,
                    FlawsAndDamages = rental.FlawsAndDamages,
                    RoomNumber = rentalRoom.RoomNumber,
                    SquareFootage = rentalRoom.SquareFootage,
                    MaxOccupancy = rentalRoom.MaxOccupancy
                };

                db.Rentals.Add(rentalRooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (rentalRoom.RoomNumber == null && rentalEquipment.PurchasePrice == null)
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
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            TempData["previous"] = rental;
            return View(rental);


        }


        // POST: Rent/Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages")] Rental rental, bool? chokingHazard, bool? suffocationHazard, int? purchasePrice, int? roomNumber, int? squareFootage, int? maxOccupancy)
        {
            if (ModelState.IsValid)
            {
                RentalEquipment previousEntryEq = (RentalEquipment)(TempData["previous"] == null ? db.Rentals.Find(rental.RentalId) :
                    (RentalEquipment)TempData["previous"]);

                RentalRoom previousEntryRm = (RentalRoom)(TempData["previous"] == null ? db.Rentals.Find(rental.RentalId) :
                    (RentalEquipment)TempData["previous"]);

                Rental previousEntryR = (Rental)(TempData["previous"] == null ? db.Rentals.Find(rental.RentalId) :
                    (RentalEquipment)TempData["previous"]);

                //,ChokingHazard,SuffocationHazard,PurchasePrice,RoomNumber,SquareFootage,MaxOccupancy"
                //while(Convert.ToBoolean(ERentalType.RentalEquipment))


                if (purchasePrice != null)
                {
                    var rentalEquipments = new RentalEquipment
                    {
                        RentalId = rental.RentalId,
                        RentalName = rental.RentalName,
                        RentalCost = rental.RentalCost,
                        FlawsAndDamages = rental.FlawsAndDamages,
                        ChokingHazard = Convert.ToBoolean(chokingHazard),
                        SuffocationHazard = Convert.ToBoolean(suffocationHazard),
                        PurchasePrice = Convert.ToInt32(purchasePrice)
                        //SuffocationHazard = rentalEquipment.SuffocationHazard,
                        //PurchasePrice = rentalEquipment.PurchasePrice
                    };

                    

                    db.Entry(rentalEquipments).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");


                }

                if (roomNumber != null)
                //while(Convert.ToBoolean(ERentalType.RentalRoom))
                {
                    var rentalRooms = new RentalRoom
                    {
                        RentalId = rental.RentalId,
                        RentalName = rental.RentalName,
                        RentalCost = rental.RentalCost,
                        FlawsAndDamages = rental.FlawsAndDamages,
                        RoomNumber = Convert.ToInt32(roomNumber),
                        SquareFootage = Convert.ToInt32(squareFootage),
                        MaxOccupancy = Convert.ToInt32(maxOccupancy)
                    };

                    db.Entry(rentalRooms).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                if (roomNumber == null && purchasePrice == null)
                {
                    db.Entry(rental).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(rental);

            }


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
