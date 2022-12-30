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
            return View(db.CastMembers.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string firstName, int yearJoined, string mainRole, string myBio, bool currentMember, string myCharacter, int castYearLeft, int debutYear)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var castmember = new CastMember();
                castmember.Name = firstName;
                castmember.YearJoined = Convert.ToInt32(yearJoined);
                castmember.MainRole = mainRole;
                castmember.Bio = myBio;
                castmember.CurrentMember = Convert.ToBoolean(currentMember);
                castmember.Character = myCharacter;
                castmember.CastYearLeft = castYearLeft;
                castmember.DebutYear = debutYear;

                db.CastMembers.Add(castmember);
                db.SaveChanges();
            }
            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMember member = db.CastMembers.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string firstName, int yearJoined, string mainRole, string myBio, bool currentMember, string myCharacter, int castYearLeft, int debutYear)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var castmember = new CastMember();
                castmember.Name = firstName;
                castmember.YearJoined = Convert.ToInt32(yearJoined);
                castmember.MainRole = mainRole;
                castmember.Bio = myBio;
                castmember.CurrentMember = Convert.ToBoolean(currentMember);
                castmember.Character = myCharacter;
                castmember.CastYearLeft = castYearLeft;
                castmember.DebutYear = debutYear;

                db.Entry(castmember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMember member = db.CastMembers.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CastMember member = db.CastMembers.Find(id);
            db.CastMembers.Remove(member);
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