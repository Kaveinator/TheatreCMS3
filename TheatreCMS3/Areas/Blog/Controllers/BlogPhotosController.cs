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
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;

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
        public ActionResult Create([Bind(Include = "BlogPhotoId,PhotoName,")] BlogPhoto blogPhoto, HttpPostedFileBase BPimage)//took photo out of bind and added BPimage parameter
        {
            if (ModelState.IsValid)
            {
                var convBPImg = convertPhoto(BPimage);

                blogPhoto.Photo = convBPImg;

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
        public ActionResult Edit([Bind(Include = "BlogPhotoId,PhotoName,Photo")] BlogPhoto blogPhoto, HttpPostedFileBase imgEdit)
        {
            if (ModelState.IsValid)
            {
               
                
                    var convBPImg = convertPhoto(imgEdit);

                    blogPhoto.Photo = convBPImg;

                    
                                             
                    db.Entry(blogPhoto).State = EntityState.Modified;
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
        //convert image file to byte[]
        public byte[] convertPhoto(HttpPostedFileBase filePic)
        {
            
                byte[] convImg;

                using (BinaryReader br = new BinaryReader(filePic.InputStream))
                {
                    convImg = br.ReadBytes(filePic.ContentLength);
                }

                return convImg;
                                    
        }
      
    }
}
