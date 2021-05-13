using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
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
            return View(db.BlogPhotos.ToList());
        }

        // GET: Blog/BlogPhotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhotos.Find(id);
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

        // This action handles the form POST and the upload
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }

        // POST: Blog/BlogPhotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogPhotoId,Title,Photo")] BlogPhoto blogPhoto)
        {

            if (ModelState.IsValid)
            {
                db.BlogPhotos.Add(blogPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPhoto);
        }

        //private static void Form1_Load(object sender, EventArgs e)
        //{
        //    // create an Image object from File
        //    Image image = Image.FromFile(//ADD String Variable here once completed;
        //                                 // create a MemoryStream 
        //    var ms = new MemoryStream();  // this is where we are going to deposit the bytes
        //                                  // save bytes to ms
        //    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    // to get the bytes we type
        //    var bytes = ms.ToArray();
        //    // we can now save the byte array to a db, file, or transport (stream) it.
        //}

        // GET: Blog/BlogPhotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPhoto blogPhoto = db.BlogPhotos.Find(id);
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
        public ActionResult Edit([Bind(Include = "BlogPhotoId,Title,Photo")] BlogPhoto blogPhoto)
        {
            if (ModelState.IsValid)
            {
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
            BlogPhoto blogPhoto = db.BlogPhotos.Find(id);
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
            BlogPhoto blogPhoto = db.BlogPhotos.Find(id);
            db.BlogPhotos.Remove(blogPhoto);
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
