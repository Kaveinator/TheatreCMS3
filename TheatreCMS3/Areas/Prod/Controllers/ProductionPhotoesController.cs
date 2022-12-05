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
    public class ProductionPhotoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProductionPhotoes
        public ActionResult Index()
        {
            return View(db.ProductionPhotos.ToList());
        }

        // GET: Prod/ProductionPhotoes/Details/5
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
        public ActionResult Create([Bind(Include = "ProPhotoID,Title,Description")] ProductionPhoto productionPhoto, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
                {
                if (postedFile != null)//if the postedFile is not null then the PhotoFile will be set = to postedFile turned into a byte[]
                {
                    productionPhoto.PhotoFile = ConvertImage(postedFile);
                }
                else { }//if the posted file is null then nothing will be done
                db.ProductionPhotos.Add(productionPhoto);
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
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
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
        public ActionResult Edit([Bind(Include = "ProPhotoID,Title,Description")] ProductionPhoto productionPhoto)
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
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
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
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
            db.ProductionPhotos.Remove(productionPhoto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //this method is used in the Create() post method above, its use is to turn an uploaded image from a user into a byte[] and then stored in the database
        public byte[] ConvertImage(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
                var ms = new MemoryStream();
                bytes = ms.ToArray();
                var imgMemoryStream = new MemoryStream(bytes);
                Image imgFromStream = Image.FromStream(imgMemoryStream);
            }
            return bytes;
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
