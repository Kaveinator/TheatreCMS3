﻿using System;
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

        // GET: Prod/ProductionPhotoEntities
        public ActionResult Index()
        {
            return View(db.ProductionPhotoEntities.ToList());
        }

        // GET: Prod/ProductionPhotoEntities/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhotoEntity productionPhotoEntity = db.ProductionPhotoEntities.Find(id);
            if (productionPhotoEntity == null)
            {
                return HttpNotFound();
            }
            return View(productionPhotoEntity);
        }

        // GET: Prod/ProductionPhotoEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/ProductionPhotoEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description")] ProductionPhotoEntity productionPhotoEntity, HttpPostedFileBase photoFile) {
            if (ModelState.IsValid) {
                if (photoFile == null || photoFile.ContentLength == 0)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                using (var binaryReader = new BinaryReader(photoFile.InputStream))
                    productionPhotoEntity.PhotoFile = binaryReader.ReadBytes(photoFile.ContentLength);
                db.ProductionPhotoEntities.Add(productionPhotoEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionPhotoEntity);
        }

        // GET: Prod/ProductionPhotoEntities/View/5
        public ActionResult View(long? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ProductionPhotoEntity entity = db.ProductionPhotoEntities.Find(id);
            if (entity == null)
                return HttpNotFound();
            return File(entity.PhotoFile, "image/*"); // TODO: Determine mime somehow
        }

        // GET: Prod/ProductionPhotoEntities/Edit/5
        public ActionResult Edit(long? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ProductionPhotoEntity productionPhotoEntity = db.ProductionPhotoEntities.Find(id);
            if (productionPhotoEntity == null)
                return HttpNotFound();
            return View(productionPhotoEntity);
        }

        // POST: Prod/ProductionPhotoEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhotoEntity productionPhotoEntity, HttpPostedFileBase photoFile) {
            if (ModelState.IsValid) {
                using (var db = this.db) {
                    db.ProductionPhotoEntities.Attach(productionPhotoEntity);
                    // Only update the photo if one was supplied
                    var entry = db.Entry(productionPhotoEntity);
                    entry.State = EntityState.Modified;
                    if (0 < (photoFile?.ContentLength ?? 0)) {
                        using (var binaryReader = new BinaryReader(photoFile.InputStream))
                            productionPhotoEntity.PhotoFile = binaryReader.ReadBytes(photoFile.ContentLength);
                    } else {
                        entry.Property(p => p.PhotoFile).IsModified = false;
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Details", new { id = productionPhotoEntity.ProPhotoId });
            }
            return View(productionPhotoEntity);
        }

        // GET: Prod/ProductionPhotoEntities/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhotoEntity productionPhotoEntity = db.ProductionPhotoEntities.Find(id);
            if (productionPhotoEntity == null)
            {
                return HttpNotFound();
            }
            return View(productionPhotoEntity);
        }

        // POST: Prod/ProductionPhotoEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductionPhotoEntity productionPhotoEntity = db.ProductionPhotoEntities.Find(id);
            db.ProductionPhotoEntities.Remove(productionPhotoEntity);
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
