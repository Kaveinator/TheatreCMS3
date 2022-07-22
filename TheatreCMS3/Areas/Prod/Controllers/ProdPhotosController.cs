using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class ProdPhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProdPhotos
        public ActionResult Index()
        {
            return View(db.ProdPhotos.ToList());
        }

        // GET: Prod/ProdPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdPhoto prodPhoto = db.ProdPhotos.Find(id);
            if (prodPhoto == null)
            {
                return HttpNotFound();
            }
            return View(prodPhoto);
        }

        // GET: Prod/ProdPhotos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/ProdPhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProPhotoId,PhotoFile,Title,Description")] ProdPhoto prodPhoto, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                prodPhoto.PhotoFile = convertImage(postedFile);

                db.ProdPhotos.Add(prodPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prodPhoto);
        }

        // GET: Prod/ProdPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdPhoto prodPhoto = db.ProdPhotos.Find(id);
            if (prodPhoto == null)
            {
                return HttpNotFound();
            }
            return View(prodPhoto);
        }

        // POST: Prod/ProdPhotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProPhotoId,Title,Description")] ProdPhoto prodPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodPhoto);
        }

        // GET: Prod/ProdPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdPhoto prodPhoto = db.ProdPhotos.Find(id);
            if (prodPhoto == null)
            {
                return HttpNotFound();
            }
            return View(prodPhoto);
        }

        // POST: Prod/ProdPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdPhoto prodPhoto = db.ProdPhotos.Find(id);
            db.ProdPhotos.Remove(prodPhoto);
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


        //Convert image to byte 

        public byte[] convertImage(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            return bytes;
        }

    }
}
