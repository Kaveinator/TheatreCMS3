using Microsoft.AspNet.Identity;
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
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/Comments
        public ActionResult Index()
        {
            return View(db.Comments.ToList());
        }


        public string TimeSinceComment(DateTime date)
        {
            string timeSinceString;
            var timeSince = DateTime.Now - date;

            if(timeSince.TotalSeconds < 60)
            {
                timeSinceString = "Just Now";
                return timeSinceString;
            }
            else if (timeSince.TotalSeconds < 120)
            {
                timeSinceString = "1 minute ago";
                return timeSinceString;
            }
            else if (timeSince.TotalSeconds < 3600)
            {
                timeSinceString = (Convert.ToInt32(Math.Floor(timeSince.TotalSeconds / 60))) + " minutes ago";
                return timeSinceString;
            }
            else if (timeSince.TotalSeconds < 7200)
            {
                timeSinceString =  "1 hour ago";
                return timeSinceString;
            }
            else if (timeSince.TotalSeconds < 86400)
            {
                timeSinceString = (Convert.ToInt32(Math.Floor(timeSince.TotalSeconds / 3600))) + " hours ago";
                return timeSinceString;
            }
            else if (timeSince.TotalSeconds < 172800)
            {
                timeSinceString = "1 day ago";
                return timeSinceString;
            }
            else
            {
                timeSinceString = (Convert.ToInt32(Math.Floor(timeSince.TotalSeconds / 86400))) + " days ago";
                return timeSinceString;
            }
        }


        // GET: Blog/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Blog/Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Message,CommentDate,Likes,Dislikes")] Comment comment)
        {
            
            if(User.Identity.GetUserName() == "")
            {
                comment.Author = "Anonymous";
            }
            else
            {
                comment.Author = User.Identity.GetUserName();
            }

            comment.Likes = 0;
            comment.Dislikes = 0;
            comment.CommentDate = DateTime.Now;

            if (ModelState.IsValid)
            {               
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: Blog/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Blog/Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Message,CommentDate,Likes,Dislikes")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Blog/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Blog/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
