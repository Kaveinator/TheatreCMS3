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
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class ProductionPhotoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProductionPhotoes
        public ActionResult Index()
        {
            var model = db.ProductionPhotos.GroupBy(t => t.Title).Select(g => new ProductionPhotoViewModel
            {   ProductionTitle = g.Key,
                ProdPhotos = g
            });
            return View(model.ToList());
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
        public ActionResult Create([Bind(Include = "ProPhotoId,Title,Description, PhotoFile")] ProductionPhoto productionPhoto, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid && photo != null && photo.ContentLength > 0)
            {
               
                byte[] bytes;
                //Converts uploaded photo to byte
                using (BinaryReader br = new BinaryReader(photo.InputStream))
                {
                    bytes = br.ReadBytes(photo.ContentLength);
                }

                productionPhoto.PhotoFile = bytes;

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
        public ActionResult Edit([Bind(Include = "ProPhotoId,Title,Description, PhotoFile")] ProductionPhoto productionPhoto, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(photo.InputStream))
                    {
                        bytes = br.ReadBytes(photo.ContentLength);
                    }

                    productionPhoto.PhotoFile = bytes;

                }

                db.Entry(productionPhoto).State = EntityState.Modified;
                if(photo == null) //if no photo was uploaded, leave original photo
                {
                    db.Entry(productionPhoto).Property(x => x.PhotoFile).IsModified = false;
                }
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //GET the byte of a ProductionPhotos object 
        [HttpGet]
        public ActionResult GetImage(int id)
        {
            var productionPhoto = db.ProductionPhotos.Find(id);
            if (productionPhoto != null && productionPhoto != null)
            {
                //Returns image file in JPEG format
                return new FileContentResult(productionPhoto.PhotoFile, "image/jpeg");
            }
            
             return null;
            
        }
    }
}
