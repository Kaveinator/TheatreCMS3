﻿using System;
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
    public class ProductionMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProductionMembers
        public ActionResult Index()
        {
            return View(db.productionMembers.ToList());
        }

        // GET: Prod/ProductionMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionMember productionMember = db.productionMembers.Find(id);
            if (productionMember == null)
            {
                return HttpNotFound();
            }
            return View(productionMember);
        }

        // GET: Prod/ProductionMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/ProductionMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductionMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,CastYearLeft,DebutYearLeft")] ProductionMember productionMember)
        {
            if (ModelState.IsValid)
            {
                db.productionMembers.Add(productionMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionMember);
        }

        // GET: Prod/ProductionMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionMember productionMember = db.productionMembers.Find(id);
            if (productionMember == null)
            {
                return HttpNotFound();
            }
            return View(productionMember);
        }

        // POST: Prod/ProductionMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,CastYearLeft,DebutYearLeft")] ProductionMember productionMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productionMember);
        }

        // GET: Prod/ProductionMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionMember productionMember = db.productionMembers.Find(id);
            if (productionMember == null)
            {
                return HttpNotFound();
            }
            return View(productionMember);
        }

        // POST: Prod/ProductionMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionMember productionMember = db.productionMembers.Find(id);
            db.productionMembers.Remove(productionMember);
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
