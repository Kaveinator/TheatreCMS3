using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class ProductionPhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProductionPhotos
        public ActionResult Index()
        {
            return View(db.ProductionPhotos.ToList());
        }


        // GET: Prod/ProductionPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
            if (productionPhoto == null)
            {
                return HttpNotFound();
            }
            return View(productionPhoto);
        }

        // GET: Prod/ProductionPhotos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/ProductionPhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductionPhotodId,Title,Description")] ProductionPhoto productionPhoto, HttpPostedFileBase Photo)
        {
            

            var photobyte = PhotoConvert(Photo);
            if (ModelState.IsValid)
            {
                productionPhoto.Photo = photobyte;
                db.ProductionPhotos.Add(productionPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            

            return View(productionPhoto);
        }

        // GET: Prod/ProductionPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
            if (productionPhoto == null)
            {
                return HttpNotFound();
            }
            return View(productionPhoto);
        }

        // POST: Prod/ProductionPhotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionPhotodId,Title,Description")] ProductionPhoto productionPhoto, HttpPostedFileBase Photo)
        {
            
            
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    var photobyte = PhotoConvert(Photo);
                    productionPhoto.Photo = photobyte;
                }
                //else
                //{

                //    //    var tempPhoto = db.ProductionPhotos.Find(productionPhoto.ProductionPhotodId);
                //    //    //productionPhoto.Photo = tempPhoto.Photo;
                //    //    var photobyte = tempPhoto.Photo;
                //    productionPhoto.Photo = db.ProductionPhotos.Find(productionPhoto.Photo);


                //}

                db.Entry(productionPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productionPhoto);
        }

        // GET: Prod/ProductionPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
            if (productionPhoto == null)
            {
                return HttpNotFound();
            }
            return View(productionPhoto);
        }

        // POST: Prod/ProductionPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
            db.ProductionPhotos.Remove(productionPhoto);
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

        public byte[] PhotoConvert(HttpPostedFileBase photo)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(photo.InputStream))
            {
                bytes = br.ReadBytes(photo.ContentLength);
            }
            return bytes;
        }


        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public byte[] GetImageFromDataBase(int Id)
        {
            var q = from temp in db.ProductionPhotos where temp.ProductionPhotodId == Id select temp.Photo;
            byte[] cover = q.First();
            return cover;
        }


    }
}
