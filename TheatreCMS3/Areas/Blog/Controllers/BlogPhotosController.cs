using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;
using System.IO;

namespace TheatreCMS3.Areas.Blog.Controllers
{
    public class BlogPhotosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/BlogPhotos
        public ActionResult Index()
        {
            return View(db.BlogPhotoes.ToList());
        }

        // GET: Blog/BlogPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
            if (blogPhoto == null)
            {
                return HttpNotFound();
            }
            return View(blogPhoto);
        }

        // GET: Blog/BlogPhotos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/BlogPhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogPhotoId,Title,Photo")] BlogPhoto blogPhoto, HttpPostedFileBase file)
        {
            // Convert photo file to byte[]
            blogPhoto.Photo = PhotoToByte(file);

            if (ModelState.IsValid)
            {
                db.BlogPhotoes.Add(blogPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPhoto);
        }

        // GET: Blog/BlogPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);

            if (blogPhoto == null)
            {
                return HttpNotFound();
            }
            return View(blogPhoto);
        }

        // POST: Blog/BlogPhotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogPhotoId,Title,Photo")] BlogPhoto blogPhoto, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                BlogPhoto currentDBItem = db.BlogPhotoes.Find(blogPhoto.BlogPhotoId);

                if (file != null)
                {
                    currentDBItem.Photo = PhotoToByte(file);
                }
                else
                {
                    currentDBItem.Photo = currentDBItem.Photo;
                }
                currentDBItem.Title = blogPhoto.Title;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPhoto);
        }

        // GET: Blog/BlogPhotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
            if (blogPhoto == null)
            {
                return HttpNotFound();
            }
            return View(blogPhoto);
        }

        // POST: Blog/BlogPhotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
            db.BlogPhotoes.Remove(blogPhoto);
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


        //turn image to a byte array to store in db
        public static byte[] PhotoToByte(HttpPostedFileBase img)
        {

            byte[] bytes;

            using (BinaryReader br = new BinaryReader(img.InputStream))
                bytes = br.ReadBytes(img.ContentLength);

            return bytes;
        }

        //return image from byte array in database
        public ActionResult GetPhoto(int id)
        {
            //get image from blog photo db item id
            byte[] bytes = db.BlogPhotoes.Find(id).Photo;

            if (bytes == null)
                return null;
            //return byte array as an image file
            return File(bytes, "image/jpeg");
        }

    }
}
