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
    public class ProductionMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProductionMembers
        public ActionResult Index()
        {
            return View(db.ProductionMembers.ToList());
        }

        // GET: Prod/ProductionMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionMember productionMember = db.ProductionMembers.Find(id);
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
        public ActionResult Create([Bind(Include = "ProductionMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYearLeft")] ProductionMember productionMember, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    db.ProductionMembers.Add(productionMember);
                    productionMember.Photo = ImgtoByte(imgFile);
                }
                else
                {
                    db.ProductionMembers.Add(productionMember);
                }
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
            ProductionMember productionMember = db.ProductionMembers.Find(id);
            if (productionMember == null)
            {
                return HttpNotFound();
            }
            //  TempData to pass value to a different method
            TempData["previousMember"] = productionMember;
            return View(productionMember);
        }

        // POST: Prod/ProductionMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionMemberId,Name,YearJoined,MainRole,Bio,CurrentMember,Character,CastYearLeft,DebutYearLeft,Photo")] ProductionMember productionMember, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form["Save"] != null)
                {                
                    //  Retrieves TempData
                    ProductionMember previousMember = TempData["previousMember"] == null ? db.ProductionMembers.Find(productionMember.ProductionMemberId) :
                       (ProductionMember)TempData["previousMember"];
                    if (imgFile != null)
                    {
                        productionMember.Photo = ImgtoByte(imgFile);
                    }
                    //  If no file is uploaded but productionMember has a photo, this ensures that the productionMember.Photo is kept instead of changing to a null value.
                    if (imgFile == null && productionMember.Photo == null && previousMember.Photo != null)
                    {
                        productionMember.Photo = previousMember.Photo;
                    }
                    db.Entry(productionMember).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else if (Request.Form["Remove"] != null)
                {
                    RemoveImage(productionMember);
                    return RedirectToAction("Edit", new { id = productionMember.ProductionMemberId });
                }

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
            ProductionMember productionMember = db.ProductionMembers.Find(id);
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
            ProductionMember productionMember = db.ProductionMembers.Find(id);
            db.ProductionMembers.Remove(productionMember);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Retrieves uploaded img file and converts into byte[]
        public byte[] ImgtoByte(HttpPostedFileBase imgFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(imgFile.InputStream))
            {
                bytes = br.ReadBytes(imgFile.ContentLength);
            }
            return bytes;
        }

        // Retrieves byte[] of ProductionMember from database
        public byte[] ImgfrmDb(int id)
        {
            ProductionMember member = db.ProductionMembers.Find(id);
            byte[] memberPhoto = member.Photo;
            return memberPhoto;
        }
        // Retrieves img file from db and displays
        public ActionResult DisplayImg(ProductionMember id)
        {
            ProductionMember member = db.ProductionMembers.Find(id.ProductionMemberId);
                byte[] img = ImgfrmDb(member.ProductionMemberId);
                if (img != null)
                {
                    return base.File(img, "image/png");
                }
                else return null;
        }

        // Removes img from database on Edit page
        public ProductionMember RemoveImage(ProductionMember productionMember)
        {
            ProductionMember member = db.ProductionMembers.Find(productionMember.ProductionMemberId);
            if (member == null)
            {
                return null;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    member.Photo = null;
                    db.Entry(member).State = EntityState.Modified;
                    db.SaveChanges();
                    return productionMember;
                }
            }
            return productionMember;
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
