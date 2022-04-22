using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class TheatreMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/TheatreMembers
        public ActionResult Index()
        {
            return View(db.TheatreMembers.ToList());
        }

        // GET: Prod/TheatreMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheatreMember theatreMember = db.TheatreMembers.Find(id);
            if (theatreMember == null)
            {
                return HttpNotFound();
            }
            return View(theatreMember);
        }

        // GET: Prod/TheatreMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/TheatreMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TheatreMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYearLeft,Photo")] TheatreMember theatreMember, HttpPostedFileBase uploadedImage)
        {
            if (ModelState.IsValid)
            {
                theatreMember.Photo = ConvertToBytes(uploadedImage);
                db.TheatreMembers.Add(theatreMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theatreMember);
        }

        // GET: Prod/TheatreMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheatreMember theatreMember = db.TheatreMembers.Find(id);
            if (theatreMember == null)
            {
                return HttpNotFound();
            }
            return View(theatreMember);
        }

        // POST: Prod/TheatreMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TheatreMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYearLeft,Photo")] TheatreMember theatreMember, HttpPostedFileBase uploadedImage)
        {
            if (ModelState.IsValid)
            {
                theatreMember.Photo = ConvertToBytes(uploadedImage);
                db.Entry(theatreMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theatreMember);
        }

        // GET: Prod/TheatreMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheatreMember theatreMember = db.TheatreMembers.Find(id);
            if (theatreMember == null)
            {
                return HttpNotFound();
            }
            return View(theatreMember);
        }

        // POST: Prod/TheatreMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheatreMember theatreMember = db.TheatreMembers.Find(id);
            db.TheatreMembers.Remove(theatreMember);
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

        [HttpPost]
        public byte[] ConvertToBytes(HttpPostedFileBase uploadedImage)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(uploadedImage.InputStream))
            {
                bytes = br.ReadBytes(uploadedImage.ContentLength);
            }
            return bytes;
        }
    }
}
