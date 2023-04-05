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

        public ActionResult ViewComments()
        {
            return View(db.Comments.ToList());
        }

        public JsonResult AddLike(int id)
        {
            var Comment = db.Comments.Find(id);
            Comment.Likes += 1;
            db.Entry(Comment).State = EntityState.Modified;
            int result = Comment.Likes;
            db.SaveChanges();
            return Json(result);
        }

        public JsonResult AddDislike(int id)
        {
            var Comment = db.Comments.Find(id);
            Comment.Dislikes += 1;
            db.Entry(Comment).State = EntityState.Modified;
            int result = Comment.Dislikes;
            db.SaveChanges();
            return Json(result);
        }

        public JsonResult Ratio(int id)
        {
            var Comment = db.Comments.Find(id);
            double LikeRatio = Comment.LikeRatio();
            double DislikeRatio = 100 - LikeRatio;
            List<double> Ratios = new List<double> { LikeRatio, DislikeRatio };
            return Json(Ratios);
        }
        public JsonResult Delete(int id)
        {
            var Comment = db.Comments.Find(id);
            db.Comments.Remove(Comment);
            db.SaveChanges();
            return Json(id);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Message,Likes,Dislikes")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                //comment.CommentDate = DateTime.Now;
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
