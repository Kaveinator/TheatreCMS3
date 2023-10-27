﻿using System;
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
            var RentalTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Select an Option", Value = "Select an Option" },
                new SelectListItem { Text = "Rental", Value = "Rental" },
                new SelectListItem { Text = "RentalEquipment", Value = "RentalEquipment" },
                new SelectListItem { Text = "RentalRoom", Value = "RentalRoom" }
            };

            ViewBag.RentalTypes = new SelectList(RentalTypes, "Text", "Value");

            return View();
        }

        // POST: Rent/Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

  
        public ActionResult Create(Rental rental)
        {
            
            //this saves it to the database 
            if (ModelState.IsValid)
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
        public ActionResult Edit(Rental rental)
        {
            var RentalTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Select an Option", Value = "Select an Option" },
                new SelectListItem { Text = "Rental", Value = "Rental" },
                new SelectListItem { Text = "RentalEquipment", Value = "RentalEquipment" },
                new SelectListItem { Text = "RentalRoom", Value = "RentalRoom" }
            };

            ViewBag.RentalTypes = new SelectList(RentalTypes, "Text", "Value");

            if (ModelState.IsValid)
            {
                var clone = db.Rentals.Find(rental.RentalId);

                clone.RentalName = rental.RentalName;
                clone.RentalCost = rental.RentalCost;
                clone.FlawsAndDamages = rental.FlawsAndDamages;
                clone.RentalType = rental.RentalType;

                if (clone.RentalType == "Rental")
                {
                    rental = new Rental();
                    clone.RentalEquipment.ChokingHazard = null;
                    clone.RentalEquipment.SuffocationHazard = null;
                    clone.RentalEquipment.PurchasingPrice = null;
                    clone.RentalRoom.MaxOccupancy = null;
                    clone.RentalRoom.RoomNumber = null;
                    clone.RentalRoom.SquareFootage = null;
                }
                else if (clone.RentalType == "RentalEquipment")
                {
                    clone.RentalEquipment = new RentalEquipment();
                    clone.RentalEquipment.ChokingHazard = rental.RentalEquipment.ChokingHazard;
                    clone.RentalEquipment.SuffocationHazard = rental.RentalEquipment.SuffocationHazard;
                    clone.RentalEquipment.PurchasingPrice = rental.RentalEquipment.PurchasingPrice;
                    clone.RentalRoom.MaxOccupancy = null;
                    clone.RentalRoom.RoomNumber = null;
                    clone.RentalRoom.SquareFootage = null;
                }
                else if (clone.RentalType == "RentalRoom")
                {
                    clone.RentalRoom = new RentalRoom();
                    clone.RentalEquipment.ChokingHazard = null;
                    clone.RentalEquipment.SuffocationHazard = null;
                    clone.RentalEquipment.PurchasingPrice = null;
                    clone.RentalRoom.MaxOccupancy = null;
                    clone.RentalRoom.RoomNumber = null;
                    clone.RentalRoom.SquareFootage = null;
                }


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
