using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO; // Added for MemoryStream
using System.Linq;
using System.Net;
using System.Threading.Tasks; // Added for async/await
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Controllers
{
    public class BlogPhotoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/BlogPhotoes
        public ActionResult Index()
        {
            return View(db.BlogPhotoes.ToList());
        }

        // GET: Blog/BlogPhotoes/Details/5
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

        // GET: Blog/BlogPhotoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/BlogPhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BlogPhotoId,Title")] BlogPhoto blogPhoto, HttpPostedFileBase imageFile) 
        {
            if (ModelState.IsValid && imageFile != null && imageFile.ContentLength > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.InputStream.CopyTo(memoryStream);
                    blogPhoto.Photo = memoryStream.ToArray();
                }

                db.BlogPhotoes.Add(blogPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPhoto);
        }

        // GET: Blog/BlogPhotoes/Edit/5
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

        // POST: Blog/BlogPhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BlogPhotoId,Title,Photo")] BlogPhoto blogPhoto) 
        {
            if (ModelState.IsValid)
            {
                if (blogPhoto.Photo != null && blogPhoto.Photo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream(blogPhoto.Photo))
                    {
                        var photoBytes = new byte[memoryStream.Length];
                        await memoryStream.ReadAsync(photoBytes, 0, photoBytes.Length);
                        blogPhoto.Photo = photoBytes;
                    }
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
            BlogPhoto blogPhoto = db.BlogPhotoes.Find(id);
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

        // Method to retrieve the image from the database based on the Id
        [HttpGet]
        public ActionResult GetImage(int id)
        {
            var blogPhoto = db.BlogPhotoes.Find(id);
            if (blogPhoto != null && blogPhoto.Photo != null)
            {
                return new FileContentResult(blogPhoto.Photo, "image/jpeg"); // Modify the content type according to the image type you are using (e.g., image/jpeg for JPEG images)
            }
            return null; 
        }
    }
}