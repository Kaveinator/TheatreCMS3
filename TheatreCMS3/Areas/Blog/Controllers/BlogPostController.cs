﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog
{
    public class BlogPostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/BlogPosts
        public ActionResult Index()
        {
            return View(db.BlogPost.ToList());              // if exception occurs, then in NuGet Console: type: update-database
        }

        // GET: Blog/BlogPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPost.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: Blog/BlogPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/BlogPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogPostId,Title,Contents,DateTime,Author")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.BlogPost.Add(blogPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPost);
        }

        // GET: Blog/BlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPost.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Blog/BlogPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogPostId,Title,Contents,DateTime,Author")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: Blog/BlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPost.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Blog/BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.BlogPost.Find(id);
            db.BlogPost.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /* Clicking the confirm button should delete the BlogPost without reloading the page (using Ajax is one possible solution) */
        // send back Json response to Ajax
        [HttpPost]                                                  // for ConfirmDelete' type: Post.
        public JsonResult AjaxDelete(int id)
        {
            BlogPost blogPost = db.BlogPost.Find(id);
            var results = new JsonResult();                         // starting JsonResult.
            results.Data = new List<string>() { blogPost.Title };   // putting the data which list of strings as results. can be anything, not a string.

            db.BlogPost.Remove(blogPost);                           // remove from dB.
            db.SaveChanges();

                    
            return Json(results, JsonRequestBehavior.AllowGet);     // return statement. JsonRequestBehavior.AllowGet= json response is accessible.
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
