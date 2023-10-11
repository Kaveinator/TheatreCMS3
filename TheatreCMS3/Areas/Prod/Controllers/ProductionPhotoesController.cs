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
    public class ProductionPhotoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProductionPhotoes
        public ActionResult Index()
        {
            return View(db.ProductionPhotoes.ToList());
        }

        // GET: Prod/ProductionPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProductionPhotoes.Find(id);
            if (productionPhoto == null)
            {
                return HttpNotFound();
            }
            return View(productionPhoto);
        }

        // GET: Prod/ProductionPhotoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/ProductionPhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhoto productionPhoto)
        {
            if (ModelState.IsValid)
            {
                if (productionPhoto != null)
                {
                    productionPhoto.PhotoFile = ConvertImage(productionPhoto);
                }

                db.ProductionPhotoes.Add(productionPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionPhoto);
        }

        // GET: Prod/ProductionPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProductionPhotoes.Find(id);
            if (productionPhoto == null)
            {
                return HttpNotFound();
            }
            return View(productionPhoto);
        }

        // POST: Prod/ProductionPhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhoto productionPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productionPhoto);
        }

        // GET: Prod/ProductionPhotoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProductionPhotoes.Find(id);
            if (productionPhoto == null)
            {
                return HttpNotFound();
            }
            return View(productionPhoto);
        }

        // POST: Prod/ProductionPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionPhoto productionPhoto = db.ProductionPhotoes.Find(id);
            db.ProductionPhotoes.Remove(productionPhoto);
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

        public byte[] ConvertToBytes(HttpPostedFileBase photo)
        {
            byte[] photoBytes;
            using (BinaryReader reader = new BinaryReader(photo.InputStream))
            {
                photoBytes = reader.ReadBytes(photo.ContentLength);
            }
            return photoBytes;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhoto productionPhoto, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    productionPhoto.PhotoFile = ConvertToBytes(photo);
                }

                db.ProductionPhotoes.Add(productionPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionPhoto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhoto productionPhoto, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                var existingPhoto = db.ProductionPhotoes.Find(productionPhoto.ProPhotoId);

                existingPhoto.Title = productionPhoto.Title;
                existingPhoto.Description = productionPhoto.Description;

                if (photo != null)
                {
                    existingPhoto.PhotoFile = ConvertToBytes(photo);
                }

                db.Entry(existingPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionPhoto);
        }

        public byte[] ConvertImage(HttpPostedFileBase productionPhoto)
        {
            byte[] bytes;

            using (BinaryReader br = new BinaryReader(productionPhoto.InputStream))
            {
                bytes = br.ReadBytes(productionPhoto.ContentLength);
            }

            return bytes;
        }

        public byte[] GetBytes(int? id)
        {
            ProductionPhoto productionPhoto = db.ProductionPhotoes.Find(id);
            byte[] bytes = productionPhoto.PhotoFile;

            return bytes;
        }
    }
}
