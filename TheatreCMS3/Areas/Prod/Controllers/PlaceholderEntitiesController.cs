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
    public class PlaceholderEntitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/PlaceholderEntities
        public ActionResult Index()
        {
            return View(db.PlaceholderEntities.ToList());
        }

        // GET: Prod/PlaceholderEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceholderEntity placeholderEntity = db.PlaceholderEntities.Find(id);
            if (placeholderEntity == null)
            {
                return HttpNotFound();
            }
            return View(placeholderEntity);
        }

        // GET: Prod/PlaceholderEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/PlaceholderEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstanceId,Value")] PlaceholderEntity placeholderEntity)
        {
            if (ModelState.IsValid)
            {
                db.PlaceholderEntities.Add(placeholderEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(placeholderEntity);
        }

        // GET: Prod/PlaceholderEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceholderEntity placeholderEntity = db.PlaceholderEntities.Find(id);
            if (placeholderEntity == null)
            {
                return HttpNotFound();
            }
            return View(placeholderEntity);
        }

        // POST: Prod/PlaceholderEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstanceId,Value")] PlaceholderEntity placeholderEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placeholderEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(placeholderEntity);
        }

        // GET: Prod/PlaceholderEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceholderEntity placeholderEntity = db.PlaceholderEntities.Find(id);
            if (placeholderEntity == null)
            {
                return HttpNotFound();
            }
            return View(placeholderEntity);
        }

        // POST: Prod/PlaceholderEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlaceholderEntity placeholderEntity = db.PlaceholderEntities.Find(id);
            db.PlaceholderEntities.Remove(placeholderEntity);
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
