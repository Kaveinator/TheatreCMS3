﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Models;
using System.Data.Entity;
using TheatreCMS3.Areas.Prod.Models;
using System.Net;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class ProductionPhotosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProductionPhoto
        public ActionResult Index()
        {
            return View(db.ProductionPhotos.ToList());
        }

        // GET: Prod/ProductionPhoto/Upload
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhoto photo)
        {
            // If form is filled out correctly, add new photo to database and redirect to index
            if (ModelState.IsValid)
            {
                db.ProductionPhotos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photo);
        }

        // GET: Prod/ProductionPhoto/Edit/5
        public ActionResult Edit(int? id)
        {
            // If no ID provided, return bad request code
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // Find photo in database by ID
            ProductionPhoto photo = db.ProductionPhotos.Find(id);

            // If photo is null, return HttpNotFound
            if (photo == null)
                return HttpNotFound();

            return View(photo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhoto photo)
        {
            // If form is filled out correctly, save changes to database and redirect to Index
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photo);
        }

        // GET: Prod/ProductionPhoto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProductionPhoto photo = db.ProductionPhotos.Find(id);

            if (photo == null)
                return HttpNotFound();

            return View(photo);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ProductionPhoto photo = db.ProductionPhotos.Find(id);

            if (photo == null)
                return HttpNotFound();

            return View(photo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionPhoto photo = db.ProductionPhotos.Find(id);
            db.ProductionPhotos.Remove(photo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}