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

namespace TheatreCMS3.Areas.Blog
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/Comment
        public ActionResult Index()
        {
            BlogPosts();
            return View(db.Comments.ToList());
        }

        /* This method get invoked when a user selects a Blog Post */
        [HttpPost]
        public ActionResult Index(int BlogPost = 0)
        {
            BlogPosts();
            List<Comment> blogPostComments = db.Comments.ToList();
            // Checks if a specific blog post was selected. 
            if (BlogPost != 0)
            {
                //finds all the comments that belong to specific blog post.
                blogPostComments = blogPostComments.Where(post => post.BlogPost.BlogPostId == BlogPost).ToList();
            }

            return View(blogPostComments);
        }
        
        public void BlogPosts()
        {
            /* From the BlogPost Db, Group by BlogPostId and select the first BlogPostId found and add it to a list. This prevents duplicate 
             * Blog Post Titles in the drop down list on the BlogPost Index page. */
            List<BlogPost> blogPostsList = db.BlogPosts.GroupBy(post => new { post.BlogPostId }).Select(i => i.FirstOrDefault()).ToList();
            /* This is what helps populate the Blog Post drop down list */
            var BlogPosts = blogPostsList.Select(i => new SelectListItem
            {
                /* The Value is wat sets the 'value' attribute in the rendered HTML and the Test is the text in
                 * between the options tag in the drop down list. */
                Value = i.BlogPostId.ToString(),
                Text = i.Title
            });

            /* ViewData returns a dictionary base on the Value and Text above. */
            ViewData["BlogPost"] = new SelectList(BlogPosts, "Value", "Text");
        }

        // GET: Blog/Comment/Details/5
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

        // GET: Blog/Comment/Create
        public ActionResult Create()
        {
            BlogPosts();
            return View();
        }

        // POST: Blog/Comment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Message,CommentDate,Likes,Dislikes")] Comment comment, int blogPost)
        {
            // This takes the number given by the drop down list in on the Create page
            // and finds the blog post with the same Id.
            BlogPost post = db.BlogPosts.Find(blogPost);
            if (ModelState.IsValid)
            {
                // This now adds the found BlogPost post and adds it to the comment's structure
                comment.BlogPost = post;
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: Blog/Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            BlogPosts();
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

        // POST: Blog/Comment/Edit/5
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

        // GET: Blog/Comment/Delete/5
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

        // POST: Blog/Comment/Delete/5
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
