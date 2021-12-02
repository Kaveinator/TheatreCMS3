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
    public class CastMemberController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/CastMember
        public ActionResult Index()
        {
            return View(db.CastMemberModels.ToList());
        }

        // GET: Prod/CastMember/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMemberModel castMemberModel = db.CastMemberModels.Find(id);
            if (castMemberModel == null)
            {
                return HttpNotFound();
            }
            return View(castMemberModel);
        }

        // GET: Prod/CastMember/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/CastMember/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CastMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYear")] CastMemberModel castMemberModel)
        {
            if (ModelState.IsValid)
            {
                db.CastMemberModels.Add(castMemberModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(castMemberModel);
        }

        // GET: Prod/CastMember/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMemberModel castMemberModel = db.CastMemberModels.Find(id);
            if (castMemberModel == null)
            {
                return HttpNotFound();
            }
            return View(castMemberModel);
        }

        // POST: Prod/CastMember/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CastMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYear")] CastMemberModel castMemberModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(castMemberModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(castMemberModel);
        }

        // GET: Prod/CastMember/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMemberModel castMemberModel = db.CastMemberModels.Find(id);
            if (castMemberModel == null)
            {
                return HttpNotFound();
            }
            return View(castMemberModel);
        }

        // POST: Prod/CastMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CastMemberModel castMemberModel = db.CastMemberModels.Find(id);
            db.CastMemberModels.Remove(castMemberModel);
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
