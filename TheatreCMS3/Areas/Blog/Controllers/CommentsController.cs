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

        // defines the LikeRatio() method for controller
        private double LikeRatio(int likes, int dislikes)
        {
            int totalUserVotes = likes + dislikes;
            
            if (totalUserVotes == 0)
            {
                return 0;
            }
            else
            {
                double ratioOfVotes = (double)likes / totalUserVotes * 100;
                return Math.Round(ratioOfVotes, 2);
            }
        }

        // GET: Blog/Comments/GetLikeRatio
        [HttpGet]
        public ActionResult GetLikeRatio(int commentId)
        {
            var comment = db.Comments.Find(commentId);
            if (comment == null)
            {
                return Json(new { error = "Comment not found." }, JsonRequestBehavior.AllowGet);
            }

            double likeRatio = LikeRatio(comment.Likes, comment.Dislikes);
            return Json(new { likeRatio = likeRatio }, JsonRequestBehavior.AllowGet);
        }

        //GET: Blog/Comments
        public ActionResult Index()
        {
            var userComments = db.Comments.ToList();

            foreach (var comment in userComments)
            {
                comment.LikeRatioValue = comment.LikeRatio();
            }

            return View(userComments);
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

        // like and dislike methods
        [HttpPost]
        public JsonResult AddLike(int id)
        {
            var comment = db.Comments.Find(id);
            if (comment == null)
            {
                return Json(new { error = "Comment not found." });
            }

            comment.Likes += 1;
            db.Entry(comment).State = EntityState.Modified;
            db.SaveChanges();

            var result = new JsonResult();
            result.Data = new { likes = comment.Likes };
            return result;
        }

        [HttpPost]
        public JsonResult AddDislike(int id)
        {
            var comment = db.Comments.Find(id);
            if (comment == null)
            {
                return Json(new { error = "Comment not found." });
            }

            comment.Dislikes += 1;
            db.Entry(comment).State = EntityState.Modified;
            db.SaveChanges();

            var result = new JsonResult();
            result.Data = new { dislikes = comment.Dislikes };
            return result;
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