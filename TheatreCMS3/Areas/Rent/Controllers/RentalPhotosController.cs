using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Rent.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Controllers
{
    public class RentalPhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/RentalPhotos
        public ActionResult Index(string searchString)
        {
            //var rentalSearchItemName = rentalPhoto.RentalsName.ToLower();
            //var rentalSearchItemDetails = rentalPhoto.Details.ToLower();
            var results = from x in db.RentalPhotoes select x;
            ViewBag.ShowList = false;
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.ShowList = true;
                results = results.Where(x => x.RentalsName.ToUpper().Contains(searchString.ToUpper()));
                //if(rentalPhoto.RentalsName.ToLower() == searchString.ToLower() || rentalPhoto.Details.ToLower() == searchString.ToLower())
            }
                {

                    return View(results);
                }
            }


        

        // GET: Rent/RentalPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalPhoto rentalPhoto = db.RentalPhotoes.Find(id);
            if (rentalPhoto == null)
            {
                return HttpNotFound();
            }
            return View(rentalPhoto);
        }

        // GET: Rent/RentalPhotos/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Rent/RentalPhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalPhotoId,RentalsName,Damaged,RentalsPhoto,Details")] RentalPhoto rentalPhoto, HttpPostedFileBase UserImageFile)
        {
            if (ModelState.IsValid)
            {
                if (UserImageFile != null)
                {
                    //converting Image to byte[] for proper storage to Db               
                    using (var binaryReader = new BinaryReader(UserImageFile.InputStream))
                    {
                        rentalPhoto.RentalsPhoto = binaryReader.ReadBytes(UserImageFile.ContentLength);
                    }
                    db.RentalPhotoes.Add(rentalPhoto);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(rentalPhoto);
        }

        // GET: Rent/RentalPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalPhoto rentalPhoto = db.RentalPhotoes.Find(id);
            if (rentalPhoto == null)
            {
                return HttpNotFound();
            }
            return View(rentalPhoto);
        }

        // POST: Rent/RentalPhotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalPhotoId,RentalsName,Damaged,RentalsPhoto,Details")] RentalPhoto rentalPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalPhoto);
        }

        // GET: Rent/RentalPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalPhoto rentalPhoto = db.RentalPhotoes.Find(id);
            if (rentalPhoto == null)
            {
                return HttpNotFound();
            }
            return View(rentalPhoto);
        }

        // POST: Rent/RentalPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalPhoto rentalPhoto = db.RentalPhotoes.Find(id);
            db.RentalPhotoes.Remove(rentalPhoto);
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










