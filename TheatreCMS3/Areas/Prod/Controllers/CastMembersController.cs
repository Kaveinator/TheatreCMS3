using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
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
            
            ViewBag.ProductionTitles = GetProductionTitles();
            return View(db.CastMembers.Include(x => x.Productions).ToList());
        }

        // GET: Prod/CastMembers/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastMember castMember = db.CastMembers.Find(id);
           
            ViewBag.ProductionTitles = GetProductionTitles(castMember);
            if (castMember == null)
            {
                return HttpNotFound();
            }
            return View(castMember);
        }
         
        // GET: Prod/CastMembers/Create
        public ActionResult Create()
        {

            CastMember castMember = new CastMember();
            castMember.ProductionsListItems = GetProductionList();
          
            
            return View(castMember);
        }

        // POST: Prod/CastMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IEnumerable<string> selectedProductions, [Bind(Include = "CastMemberID,Name,YearJoined,ProductionTitles,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYear, File")] CastMember castMember)
        {
           
            if (ModelState.IsValid)
            {
                if(selectedProductions == null)             //Null Protection, needs improvement.
                {
                     Content("<script language='javascript' type='text/javascript'>alert('Please Go Back and Select a Production!');</script>");
                    return RedirectToAction("Create");
                }
                castMember.SelectedProductions = selectedProductions;        //Save Production selection to model.
                foreach(string selection in castMember.SelectedProductions)  //Then populate CastMember.Productions
                {
                    int selectionInt = Int32.Parse(selection);

                   db.Productions.Where(p => p.ProductionId == selectionInt).SingleOrDefault();
                    castMember.Productions.Add(db.Productions.Where(p => p.ProductionId == selectionInt).SingleOrDefault());
                }
                

                castMember.Photo = FileToBytes(castMember.File);           //Convert Uploaded photo file to Byte[]
                
                db.CastMembers.Add(castMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(castMember);
        }

        // GET: Prod/CastMembers/Edit/5                                                           Needs:  Pre-Select Existing Producitons
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
            
            castMember.ProductionsListItems = GetProductionList();
            return View(castMember);
        }

       

        // POST: Prod/CastMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IEnumerable<string> selectedProductions, CastMember castMember)
        {
            if (ModelState.IsValid)
            {
                // Photo Upload
                if (castMember.File != null)
                    castMember.Photo = FileToBytes(castMember.File);

                db.Entry(castMember).State = EntityState.Modified;    //Save non-Nav properties to db before altering Nav properties. 
                db.SaveChanges();
                
                if (selectedProductions == null)             //Production ListBox Null Protection; needs improvement.
                {
                    Content("<script language='javascript' type='text/javascript'>alert('Please Go Back and Select a Production!');</script>");
                    return RedirectToAction("Edit");
                }
                var productions = db.Productions.ToHashSet<Production>();                                                                   //Create Productions List   
                castMember = db.CastMembers.Include(x => x.Productions).FirstOrDefault(x => x.CastMemberId == castMember.CastMemberId);     //repopulate castMember from db. Needed for EF change-tracking
                castMember.Productions.Clear();                                                                                             //Clear old Producitons
                foreach (string selection in castMember.SelectedProductions)  //Then populate CastMem.Productions                           //Add new Production for each selection
                {
                    int selectionInt = Int32.Parse(selection);
                    castMember.Productions.Add(productions.Where(p => p.ProductionId == selectionInt).SingleOrDefault());
                }
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
            ViewBag.ProductionTitles = GetProductionTitles(castMember);
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


        //Photo Storage and Retrieval 
        public byte[] FileToBytes(HttpPostedFileBase file)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(file.InputStream))
                bytes = br.ReadBytes(file.ContentLength);
            return bytes;
        }

        public byte[] GetBytes(int id)
        {
            return db.CastMembers.Find(id).Photo;
        }

        public ActionResult GetImage(int id)
        {
            byte[] bytes = db.CastMembers.Find(id).Photo;
            if (bytes == null) return null;
            return File(bytes, "image/jpg");
        }


        // Return a List of productions to populate dropdownlist form inputs
        public List<SelectListItem> GetProductionList()
        {
            var productions = new List<SelectListItem>();

            foreach (Production production in db.Productions)
            {
                var item = new SelectListItem
                {
                    Text = production.Title,
                    Value = production.ProductionId.ToString(),
                    Selected = production.IsSelected
                };
                productions.Add(item);
            }
            return productions;
        }
        public List<string> GetProductionTitles()
        {
            var productionTitles = new List<string>();

            foreach (Production production in db.Productions)
            {
                productionTitles.Add(production.Title);
            }
            return productionTitles;
        }
        public List<string> GetProductionTitles(CastMember castMember)
        {
            var productionTitles = new List<string>();

            foreach (Production production in castMember.Productions)
            {
                productionTitles.Add(production.Title);
            }
            return productionTitles;
        }



    }
}
