﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
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

            // Getting byte array from user
            byte[] imageBytes = GetBytes(blogPhoto.BlogPhotoId);


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
        public ActionResult Create([Bind(Include = "BlogPhotoId,Title,Photo")] BlogPhoto blogPhoto, HttpPostedFileBase blogImage)
        {
            if (ModelState.IsValid)
            {
                blogPhoto.Photo = ConvertImage(blogImage);

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
        public ActionResult Edit([Bind(Include = "BlogPhotoId,Title,Photo")] BlogPhoto blogPhoto, HttpPostedFileBase blogImage)
        {
            if (ModelState.IsValid)
            {
                if (blogImage != null)
                {
                    blogPhoto.Photo = ConvertImage(blogImage);
                    db.Entry(blogPhoto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
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
            db.BlogPhotoes.Remove(blogPhoto);
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View(blogPhoto);
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

        // POST: Blog/BlogPhotos/DeleteJson/5
        [HttpPost]
        public JsonResult DeleteJson(int id)
        {
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
            if (blogPhoto == null)
            {
                // Returns response letting user know that the record does not exist
                return Json(new { success = false, message = "Record not found." });
            }
            try
            {
                db.BlogPhotoes.Remove(blogPhoto);
                db.SaveChanges();
            }
            catch
            {

            }
            // Creating newblogPhoto to pass original blogPhoto's id back to Blog.js
            BlogPhoto newblogPhoto = new BlogPhoto
            {
                BlogPhotoId = id
            };
            return Json(newblogPhoto.BlogPhotoId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public byte[] ConvertImage(HttpPostedFileBase blogImage)
        {
            byte[] bytes;

            using (BinaryReader br = new BinaryReader(blogImage.InputStream))
            {
                bytes = br.ReadBytes(blogImage.ContentLength);
            }

            return bytes;
        }

        public byte[] GetBytes(int? id)
        {
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
            byte[] bytes = blogPhoto.Photo;

            return bytes;
        }
    }
}
