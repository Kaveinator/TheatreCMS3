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
        public ActionResult Create([Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages")] Rental rental, int? PurchasePrice, bool SuffocationHazard, bool ChokingHazard, int RoomNumber
            , int MaxOccupancy, int SquareFootage)
        { 
           
            //Logic for RentalEquipment
            if (PurchasePrice > 0)  //if PurchasePrice has value then we know we're dealing with RentalEquipment
            {
                RentalEquipment rentalequipment = new RentalEquipment();  //instantiate new instance of object rentalequipment named 'rentalequipment'
                rentalequipment.RentalName = rental.RentalName; //explicitly telling program that the RentalName field is = to the current rentals.RentalName
                rentalequipment.RentalCost = rental.RentalCost;
                rentalequipment.FlawsAndDamages = rental.FlawsAndDamages;
                rentalequipment.PurchasePrice = Convert.ToInt32(PurchasePrice); //same as above but include which class object (rentalequipment instead of rental)
                rentalequipment.SuffocationHazard = Convert.ToBoolean(SuffocationHazard);
                rentalequipment.ChokingHazard = Convert.ToBoolean(ChokingHazard); //anytime its boolean or int use convert statement define this way

                db.Rentals.Add(rentalequipment); //add new object rentalequipment to database
                db.SaveChanges();                  //save to db
                return RedirectToAction("Index");  //send user to Index page once saved


            }
            //Logic for RentalRoom
            else if (RoomNumber > 0) //if RoomNumber has value we know its a RentalRoom
            {
                RentalRoom rentalroom = new RentalRoom(); //instantiate
                rentalroom.RentalName = rental.RentalName;
                rentalroom.RentalCost = rental.RentalCost;
                rentalroom.FlawsAndDamages = rental.FlawsAndDamages;
                rentalroom.RoomNumber = Convert.ToInt32(RoomNumber);
                rentalroom.MaxOccupancy = Convert.ToInt32(MaxOccupancy);
                rentalroom.SquareFootage = Convert.ToInt32(SquareFootage);

                db.Rentals.Add(rentalroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Logic for Rental
            else if (ModelState.IsValid)  //might need indentation
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
            return View(rental);
        }

        // POST: Rent/Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages")] Rental rental, int? PurchasePrice, bool SuffocationHazard, bool ChokingHazard, int RoomNumber
            , int MaxOccupancy, int SquareFootage)
        {
            if (PurchasePrice > 0)
            {
                RentalEquipment rentalequipment = new RentalEquipment();  //instantiate new instance of object rentalequipment named 'rentalequipment'
                rentalequipment.RentalId = rental.RentalId;
                rentalequipment.RentalName = rental.RentalName; //explicitly telling program that the RentalName field is = to the current rentals.RentalName
                rentalequipment.RentalCost = rental.RentalCost;
                rentalequipment.FlawsAndDamages = rental.FlawsAndDamages;
                rentalequipment.PurchasePrice = Convert.ToInt32(PurchasePrice); //same as above but include which class object (rentalequipment instead of rental)
                rentalequipment.SuffocationHazard = Convert.ToBoolean(SuffocationHazard);
                rentalequipment.ChokingHazard = Convert.ToBoolean(ChokingHazard); //anytime its boolean or int use convert statement define this way

                //TRIED putting rentalequipment.Propname in above convert statements
                //TRIED using rental.RentalName in top of statement
                //TRIED eliminating top section of this entirely
                

                db.Entry(rentalequipment).State = EntityState.Modified;
                db.SaveChanges();                  //save to db
                return RedirectToAction("Index");  //send user to Index page once saved
            }
            else if (RoomNumber > 0)
            {
                RentalRoom rentalroom = new RentalRoom(); //instantiate
                rentalroom.RentalId = rental.RentalId;
                rentalroom.RentalName = rental.RentalName;
                rentalroom.RentalCost = rental.RentalCost;
                rentalroom.FlawsAndDamages = rental.FlawsAndDamages;
                rentalroom.RoomNumber = Convert.ToInt32(RoomNumber);
                rentalroom.MaxOccupancy = Convert.ToInt32(MaxOccupancy);
                rentalroom.SquareFootage = Convert.ToInt32(SquareFootage);

                //RentalRoom rentalroom = db.Rentals.Find(id);

                db.Entry(rentalroom).State = EntityState.Modified;
                db.SaveChanges();                  //save to db
                return RedirectToAction("Index");  //send user to Index page once saved
            }
        
            else if (ModelState.IsValid)
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
