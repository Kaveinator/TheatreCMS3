﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Rent.Models;
using TheatreCMS3.Areas.Rent.ViewModels;
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
        public ActionResult Create([Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages," +
            "ChokingHazard,SuffocationHazard,PurchasePrice," +
            "RoomNumber,SquareFootage,MaxOccupancy")] AllRentals allrentals, string name)
        {
            bool success = false;

            if (name == "rental")
            {
                success = CreateRental(allrentals);
            }
            else if (name == "equipment")
            {
                success = CreateEquipmentRental(allrentals);
            }
            else if (name == "room")
            {
                success = CreateRoomRental(allrentals);
            }
            if (success)
            {
                return RedirectToAction("Index");
            }
            return View(allrentals);
        }

        private bool CreateRental(AllRentals allrentals)
        {
            Rental rental = new Rental()
            {
                RentalName = allrentals.RentalName,
                RentalCost = allrentals.RentalCost,
                FlawsAndDamages = allrentals.FlawsAndDamages
            };

            if (ModelState.IsValidField("RentalName") && ModelState.IsValidField("RentalCost") &&
                ModelState.IsValidField("FlawsAndDamages"))
            {
                db.Rentals.Add(rental);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool CreateEquipmentRental(AllRentals allrentals)
        {
            RentalEquipment equipment = new RentalEquipment()
            {
                RentalName = allrentals.RentalName,
                RentalCost = allrentals.RentalCost,
                FlawsAndDamages = allrentals.FlawsAndDamages,
                ChokingHazard = allrentals.ChokingHazard,
                SuffocationHazard = allrentals.SuffocationHazard,
                PurchasePrice = allrentals.PurchasePrice
            };
            if (ModelState.IsValidField("RentalName") && ModelState.IsValidField("RentalCost") &&
                ModelState.IsValidField("FlawsAndDamages") && ModelState.IsValidField("ChokingHazard") &&
                ModelState.IsValidField("SuffocationHazard") && ModelState.IsValidField("PurchasePrice"))
            {
                db.Rentals.Add(equipment);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool CreateRoomRental(AllRentals allrentals)
        {
            RentalRoom room = new RentalRoom()
            {
                RentalName = allrentals.RentalName,
                RentalCost = allrentals.RentalCost,
                FlawsAndDamages = allrentals.FlawsAndDamages,
                RoomNumber = allrentals.RoomNumber,
                SquareFootage = allrentals.SquareFootage,
                MaxOccupancy = allrentals.MaxOccupancy
            };

            if (ModelState.IsValidField("RentalName") && ModelState.IsValidField("RentalCost") &&
                ModelState.IsValidField("FlawsAndDamages") && ModelState.IsValidField("RoomNumber") &&
                ModelState.IsValidField("SquareFootage") && ModelState.IsValidField("MaxOccupancy"))
            {
                db.Rentals.Add(room);
                db.SaveChanges();
                return true;
            }
            return false;
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

            AllRentals allRentals = new AllRentals(rental);
            if (rental.GetType().ToString().Contains("Equipment"))
            {
                ViewBag.rentalType = "equipment";
            }
            else if (rental.GetType().ToString().Contains("Room"))
            {
                ViewBag.rentalType = "room";
            }
            else
            {
                ViewBag.rentalType = "rental";
            }
            
            return View(allRentals);
        }

        // POST: Rent/Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalId,RentalName,RentalCost,FlawsAndDamages")] Rental rental)
        {
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
