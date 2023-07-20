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
    
    public class RentalHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/RentalHistories
        public ActionResult Index()
        {
            return View(db.RentalHistories.ToList());
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
            if (User.Identity.Name != "HistoryManager")
            {
                return View("AccessDenied");
            }
            return View();
        }

        // POST: Rent/RentalHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            if (User.Identity.Name != "HistoryManager")
            {
                return View("AccessDenied");
            }
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
            if (User.Identity.Name != "HistoryManager")
            {
                return View("AccessDenied");
            }
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

        public ActionResult Login(string admin)
        {       
            if (admin == "Admin")
            {
                if (ModelState.IsValid)
                {
                    var user = db.Users.Where(x => x.UserName == "HistoryManager").FirstOrDefault();
                }
                
            }
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
