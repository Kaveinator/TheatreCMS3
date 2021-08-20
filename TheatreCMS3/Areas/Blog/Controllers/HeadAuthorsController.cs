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
    public class HeadAuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/HeadAuthors
        public ActionResult Index()
        {
            return View(db.ApplicationUsers.ToList());
        }

        // GET: Blog/HeadAuthors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadAuthor headAuthor = db.ApplicationUsers.Find(id);
            if (headAuthor == null)
            {
                return HttpNotFound();
            }
            return View(headAuthor);
        }

        // GET: Blog/HeadAuthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/HeadAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,ViewsPerMonth,AuthorsHired,AuthorsLetGo")] HeadAuthor headAuthor)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationUsers.Add(headAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(headAuthor);
        }

        // GET: Blog/HeadAuthors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadAuthor headAuthor = db.ApplicationUsers.Find(id);
            if (headAuthor == null)
            {
                return HttpNotFound();
            }
            return View(headAuthor);
        }

        // POST: Blog/HeadAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,ViewsPerMonth,AuthorsHired,AuthorsLetGo")] HeadAuthor headAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(headAuthor);
        }

        // GET: Blog/HeadAuthors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadAuthor headAuthor = db.ApplicationUsers.Find(id);
            if (headAuthor == null)
            {
                return HttpNotFound();
            }
            return View(headAuthor);
        }

        // POST: Blog/HeadAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HeadAuthor headAuthor = db.ApplicationUsers.Find(id);
            db.ApplicationUsers.Remove(headAuthor);
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
