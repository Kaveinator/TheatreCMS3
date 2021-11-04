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

namespace TheatreCMS3.Areas.Blog.Controllers
{
    public class BlogAuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/BlogAuthor
        public ActionResult Index()
        {
            return View(db.BlogAuthor.ToList());
        }

        // GET: Blog/BlogAuthor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthor.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/BlogAuthor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogAuthorId,Name,Bio,Joined,Left")] BlogAuthor blogAuthor)
        {
            if (ModelState.IsValid)
            {
                db.BlogAuthor.Add(blogAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthor.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // POST: Blog/BlogAuthor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogAuthorId,Name,Bio,Joined,Left")] BlogAuthor blogAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthor.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // POST: Blog/BlogAuthor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogAuthor blogAuthor = db.BlogAuthor.Find(id);
            db.BlogAuthor.Remove(blogAuthor);
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
