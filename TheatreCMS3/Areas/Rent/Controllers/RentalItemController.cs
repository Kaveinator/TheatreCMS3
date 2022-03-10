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
    public class RentalItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/RentalItem
        public ActionResult Index()
        {
            return View(db.RentalItems.ToList());
        }

        // GET: Rent/RentalItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalItem rentalItem = db.RentalItems.Find(id);
            if (rentalItem == null)
            {
                return HttpNotFound();
            }
            return View(rentalItem);
        }

        // GET: Rent/RentalItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rent/RentalItem/Create
        
        // [HttpPost] is a C sharp method for posting data to the server.
        // 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "RentalItemId,Item,ItemDescription,PickupDate,ReturnDate,ItemPhoto")] RentalItem rentalItem,HttpPostedFileBase file)
        {
            //IsValid indicates if it was possible to bind the
            //incoming values from the request to the model correctly 

            if (ModelState.IsValid)
            {
                rentalItem.ItemPhoto = new byte[file.ContentLength];
                file.InputStream.Read(rentalItem.ItemPhoto, 0, file.ContentLength);
                
                db.RentalItems.Add(rentalItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalItem);
        }

        //* GET: Rent/RentalItem/Edit/5

        // NB. "null means no value. It does not mean the numeral '0'.

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalItem rentalItem = db.RentalItems.Find(id);
            if (rentalItem == null)
            {
                return HttpNotFound();
            }
            return View(rentalItem);
        }

        // *POST: Rent/RentalItem/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalItemId,Item,ItemDescription,PickupDate,ReturnDate,ItemPhoto")] RentalItem rentalItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalItem);
        }

        // GET: Rent/RentalItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalItem rentalItem = db.RentalItems.Find(id);
            if (rentalItem == null)
            {
                return HttpNotFound();
            }
            return View(rentalItem);
        }

        // POST: Rent/RentalItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalItem rentalItem = db.RentalItems.Find(id);
            db.RentalItems.Remove(rentalItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //"Protected" means this method is only accessable in this class and all child classes.
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
