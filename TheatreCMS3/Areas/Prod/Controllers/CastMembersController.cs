﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Models;
using TheatreCMS3.Models;
using System.Data.SqlClient;

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
        public ActionResult Create([Bind(Include = "ID, Name, YearJoined, MainRole, Bio, Photo, CurrentMember, Character, CastYearLeft, DebutYear")] CastMember castMember, HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            castMember.Photo = bytes;

            if (ModelState.IsValid)
            {
                db.CastMembers.Add(castMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(castMember);
        }

        // GET: Prod/CastMembers/Edit/5
        public ActionResult Edit(int? id) /*HttpPostedFileBase postedFile*/
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
            string query = "Select Content from dbo.CastMembers";
            using (SqlConnection connection = new SqlConnection(DbContext))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader d = command.ExecuteReader())
                {
                    if (d.Read())
                    {
                        byte[] byteArray = (byte[])d["Photo"];
                    }
                }
            }
            return View(castMember);
            
            
        }

        // POST: Prod/CastMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Name, YearJoined, MainRole, Bio, Photo, CurrentMember, Character, CastYearLeft, DebutYear")] CastMember castMember, HttpPostedFileBase postedFile)
        {
            //if (postedFile == null)
            //{
            //    string query = "Select Content from dbo.CastMembers";
            //    using (SqlConnection connection = new SqlConnection())
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        connection.Open();
            //        using (SqlDataReader d = command.ExecuteReader())
            //        {
            //            if (d.Read())
            //            {
            //                byte[] byteArray = (byte[])d["Photo"];
            //            }
            //        }
            //    }
            //}

            if (postedFile != null)
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(postedFile.InputStream))
                {
                    bytes = br.ReadBytes(postedFile.ContentLength);
                }
                castMember.Photo = bytes;
            }

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
    }
}
