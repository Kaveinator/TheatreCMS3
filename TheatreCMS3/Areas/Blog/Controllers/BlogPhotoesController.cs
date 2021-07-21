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
    public class BlogPhotoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/BlogPhotoes
        public ActionResult Index()
        {
            return View(db.BlogPhoto.ToList());
        }

        // GET: Blog/BlogPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhoto.Find(id);
            if (blogPhoto == null)
            {
                return HttpNotFound();
            }
            return View(blogPhoto);
        }

        // GET: Blog/BlogPhotoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/BlogPhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BlogPhotoID,Title")] BlogPhoto blogPhoto) 
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.BlogPhoto.Add(blogPhoto);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(blogPhoto);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogPhotoID,Title")] BlogPhoto blogPhoto, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    blogPhoto.Photo = new byte[photo.ContentLength];
                    photo.InputStream.Read(blogPhoto.Photo, 0, photo.ContentLength);
                    //int FileSize = photo.ContentLength;
                    //byte[] FileByteArray = new byte[FileSize];
                    //photo.InputStream.Read(FileByteArray, 0, FileSize);
                    //blogPhoto.Photo = FileByteArray;
                }

                db.BlogPhoto.Add(blogPhoto);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(blogPhoto);
        }


        //// GET: Blog/BlogPhotoes/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BlogPhoto blogPhoto = db.BlogPhoto.Find(id);
        //    if (blogPhoto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blogPhoto);
        //}

        //// POST: Blog/BlogPhotoes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BlogPhotoID,Title")] BlogPhoto blogPhoto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(blogPhoto).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(blogPhoto);
        //}


        // GET: Blog/BlogPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhoto.Find(id);
            if (blogPhoto == null)
            {
                return HttpNotFound();
            }
            return View(blogPhoto);
        }

        // POST: Blog/BlogPhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogPhotoID,Title")] BlogPhoto blogPhoto, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    blogPhoto.Photo = new byte[photo.ContentLength];
                    photo.InputStream.Read(blogPhoto.Photo, 0, photo.ContentLength);
                }
                
                db.Entry(blogPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPhoto);
        }

        // GET: Blog/BlogPhotoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhoto.Find(id);
            if (blogPhoto == null)
            {
                return HttpNotFound();
            }
            return View(blogPhoto);
        }

        // POST: Blog/BlogPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPhoto blogPhoto = db.BlogPhoto.Find(id);
            db.BlogPhoto.Remove(blogPhoto);
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
