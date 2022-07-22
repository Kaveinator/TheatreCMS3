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
    public class CastMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/CastMembers
        public ActionResult Index()
        {
            return View(db.CastMembers.ToList());
        }

        // GET: Prod/CastMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMember castMember = db.CastMembers.Find(id);
            if (castMember == null)
            {
                return HttpNotFound();
            }
            return View(castMember);
        }

        // GET: Prod/CastMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/CastMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Includes all of the columns in the database table. 
        public ActionResult Create([Bind(Include = "CastMemberId,Name,YearJoined,MainRole,Photo,Bio,CurrentMember,Character,CastYearLeft,DebutYear")] CastMember castMember, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                // postedFile is what file the user is uploading to the database.
                castMember.Photo = Conversion(postedFile);
                db.CastMembers.Add(castMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(castMember);
        }

        // GET: Prod/CastMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMember castMember = db.CastMembers.Find(id);
            if (castMember == null)
            {
                return HttpNotFound();
            }
            return View(castMember);
        }

        // POST: Prod/CastMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CastMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYear")] CastMember castMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(castMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(castMember);
        }

        // GET: Prod/CastMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMember castMember = db.CastMembers.Find(id);
            if (castMember == null)
            {
                return HttpNotFound();
            }
            return View(castMember);
        }

        // POST: Prod/CastMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CastMember castMember = db.CastMembers.Find(id);
            db.CastMembers.Remove(castMember);
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
        // This method is converting the file uploaded into a byte array which then will need to be 
        // rendered into an image.
        public byte[] Conversion(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            // BinaryReader is a class that is used to handle binary data(aka the byte array).
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                // ReadBytes reads the specified number of bytes from the current inputstream.
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            return bytes;
        }
    }
}
