using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Rent.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Controllers
{
    public class RentalSurveysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/RentalSurveys
        public ActionResult Index()
        {
            return View(db.RentalSurveys.ToList());
        }

        // GET: Rent/RentalSurveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalSurvey rentalSurvey = db.RentalSurveys.Find(id);
            if (rentalSurvey == null)
            {
                return HttpNotFound();
            }
            return View(rentalSurvey);
        }

        // GET: Rent/RentalSurveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rent/RentalSurveys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurveyID,RecommendRentalRating,RentalCost,ExperienceRating,Feedback")] RentalSurvey rentalSurvey)
        {
            if (ModelState.IsValid)
            {
                db.RentalSurveys.Add(rentalSurvey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalSurvey);
        }

        // GET: Rent/RentalSurveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalSurvey rentalSurvey = db.RentalSurveys.Find(id);
            if (rentalSurvey == null)
            {
                return HttpNotFound();
            }
            return View(rentalSurvey);
        }

        // POST: Rent/RentalSurveys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurveyID,RecommendRentalRating,RentalCost,ExperienceRating,Feedback")] RentalSurvey rentalSurvey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalSurvey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalSurvey);
        }

        // GET: Rent/RentalSurveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalSurvey rentalSurvey = db.RentalSurveys.Find(id);
            if (rentalSurvey == null)
            {
                return HttpNotFound();
            }
            return View(rentalSurvey);
        }

        // POST: Rent/RentalSurveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalSurvey rentalSurvey = db.RentalSurveys.Find(id);
            db.RentalSurveys.Remove(rentalSurvey);
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
