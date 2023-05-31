using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class CastmembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/Castmembers
        public ActionResult Index()
        {
            return View(db.Castmembers.ToList());
        }

        // GET: Prod/Castmembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Castmember castmember = db.Castmembers.Find(id);
            if (castmember == null)
            {
                return HttpNotFound();
            }
            return View(castmember);
        }

        // GET: Prod/Castmembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/Castmembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CastMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYear")] Castmember castmember)
        {
            if (ModelState.IsValid)
            {
                db.Castmembers.Add(castmember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(castmember);
        }

        // GET: Prod/Castmembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Castmember castmember = db.Castmembers.Find(id);
            if (castmember == null)
            {
                return HttpNotFound();
            }
            return View(castmember);
        }

        // POST: Prod/Castmembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CastMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYear")] Castmember castmember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(castmember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(castmember);
        }

        // GET: Prod/Castmembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Castmember castmember = db.Castmembers.Find(id);
            if (castmember == null)
            {
                return HttpNotFound();
            }
            return View(castmember);
        }

        // POST: Prod/Castmembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Castmember castmember = db.Castmembers.Find(id);
            db.Castmembers.Remove(castmember);
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
