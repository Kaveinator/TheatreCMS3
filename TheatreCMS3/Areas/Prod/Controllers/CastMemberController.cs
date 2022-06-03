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
using System.IO;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class CastMemberController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/CastMember
        public ActionResult Index()
        {
            return View(db.CastMembers.ToList());
        }

        // GET: Prod/CastMember/Details/5
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
        public ActionResult Create([Bind(Include = "CastMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYear,Photo")] CastMember castMember, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                // imageByteArray is being assigned to the castMember.Photo property here.
                castMember.Photo = ConvertImage(image);
                db.CastMembers.Add(castMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(castMember);
        }

        // GET: Prod/CastMember/Edit/5
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

        // POST: Prod/CastMember/Edit/5
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

        // GET: Prod/CastMember/Delete/5
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

        // POST: Prod/CastMember/Delete/5
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

        // Take file from Create View;
        // Convert file to Byte[] for dB;
        // Add file to dB;
        // How does it correspond to a particular castmember?
        public byte[] ConvertImage(HttpPostedFileBase image)
        {
            // Initializing empty byte array
            byte[] imageByteArray;

            // BinaryReader provides methods that simplify reading primitive data types from a stream.
            // In our case, the stream will be the client uploaded file 'image' from the 'Create' view.
            using (BinaryReader br = new BinaryReader(image.InputStream))
            {
                imageByteArray = br.ReadBytes(image.ContentLength);
            }
            return imageByteArray;
        }
    }
}
