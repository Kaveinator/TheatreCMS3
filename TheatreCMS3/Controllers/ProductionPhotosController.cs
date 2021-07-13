using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Controllers
{
    public class ProductionPhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductionPhotos
        public ActionResult Index()
        {
            return View(db.ProductionPhoto.ToList());
        }

        // GET: ProductionPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhotos productionPhotos = db.ProductionPhoto.Find(id);
            if (productionPhotos == null)
            {
                return HttpNotFound();
            }
            return View(productionPhotos);
        }

        // GET: ProductionPhotos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionPhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhotos productionPhotos)
        {
            if (ModelState.IsValid)
            {
                db.ProductionPhoto.Add(productionPhotos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionPhotos);
        }

        // GET: ProductionPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhotos productionPhotos = db.ProductionPhoto.Find(id);
            if (productionPhotos == null)
            {
                return HttpNotFound();
            }
            return View(productionPhotos);
        }

        // POST: ProductionPhotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhotos productionPhotos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionPhotos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productionPhotos);
        }

        // GET: ProductionPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhotos productionPhotos = db.ProductionPhoto.Find(id);
            if (productionPhotos == null)
            {
                return HttpNotFound();
            }
            return View(productionPhotos);
        }

        // POST: ProductionPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionPhotos productionPhotos = db.ProductionPhoto.Find(id);
            db.ProductionPhoto.Remove(productionPhotos);
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
