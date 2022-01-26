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
    public class RentalrequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/Rentalrequests
        public ActionResult Index()
        {
            return View(db.Rentalrequests.ToList());
        }

        // GET: Rent/Rentalrequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentalrequest rentalrequest = db.Rentalrequests.Find(id);
            if (rentalrequest == null)
            {
                return HttpNotFound();
            }
            return View(rentalrequest);
        }

        // GET: Rent/Rentalrequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rent/Rentalrequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalRequestID,ContactPerson,Company,RequestedTime,StartTime,EndTime,ProjectInfo,RentalCode,Accepted,ContractSigned")] Rentalrequest rentalrequest)
        {
            if (ModelState.IsValid)
            {
                db.Rentalrequests.Add(rentalrequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalrequest);
        }

        // GET: Rent/Rentalrequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentalrequest rentalrequest = db.Rentalrequests.Find(id);
            if (rentalrequest == null)
            {
                return HttpNotFound();
            }
            return View(rentalrequest);
        }

        // POST: Rent/Rentalrequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalRequestID,ContactPerson,Company,RequestedTime,StartTime,EndTime,ProjectInfo,RentalCode,Accepted,ContractSigned")] Rentalrequest rentalrequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalrequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalrequest);
        }

        // GET: Rent/Rentalrequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rentalrequest rentalrequest = db.Rentalrequests.Find(id);
            if (rentalrequest == null)
            {
                return HttpNotFound();
            }
            return View(rentalrequest);
        }

        // POST: Rent/Rentalrequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rentalrequest rentalrequest = db.Rentalrequests.Find(id);
            db.Rentalrequests.Remove(rentalrequest);
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
