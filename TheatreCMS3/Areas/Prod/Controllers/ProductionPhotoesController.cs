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
using PagedList;

namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class ProductionPhotoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProductionPhotoes
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var photoes = from x in db.ProdcutionPhotoes
                          select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                photoes = photoes.Where(x => x.Title.Contains(searchString));
            }
            
            int pageSize = 12;
            int pageNumber = (page ?? 1);

            photoes = photoes.OrderBy(x => x.Title);
            return View(photoes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Prod/ProductionPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProdcutionPhotoes.Find(id);
            if (productionPhoto == null)
            {
                return HttpNotFound();
            }
            return View(productionPhoto);
        }

        // GET: Prod/ProductionPhotoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prod/ProductionPhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        //Check if Photofile is sent through.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductionPhotoId,Title,Description,PhotoFile")] ProductionPhoto productionPhoto, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                byte[] myBytes;
                myBytes = ToByteArray(postedFile);
                productionPhoto.PhotoFile = myBytes;
                db.ProdcutionPhotoes.Add(productionPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionPhoto);
        }
        
        public byte[] ToByteArray(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            return bytes;
        }

        //public HttpPostedFileBase ToHttpPostedFileBase (int id)
        //{
            
        //    byte[] bytes;
        //    ProductionPhoto productionPhoto = db.ProdcutionPhotoes.Find(id);
        //    bytes = productionPhoto.PhotoFile;
        //    using (var ms = new MemoryStream(byteArrayIn))
        //    {
               
        //    }


        //    BinaryReader br = new BinaryReader(bytes.InputStream);
        //    HttpPostedFileBase postedFile = (HttpPostedFileBase) new Memory

        //    return postedFile;
        //}



        // GET: Prod/ProductionPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProdcutionPhotoes.Find(id);
            if (productionPhoto == null)
            {
                return HttpNotFound();
            }
            return View(productionPhoto);
        }

        // POST: Prod/ProductionPhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionPhotoId,Title,Description")] ProductionPhoto productionPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productionPhoto);
        }

        // GET: Prod/ProductionPhotoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProdcutionPhotoes.Find(id);
            if (productionPhoto == null)
            {
                return HttpNotFound();
            }
            return View(productionPhoto);
        }

        // POST: Prod/ProductionPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionPhoto productionPhoto = db.ProdcutionPhotoes.Find(id);
            db.ProdcutionPhotoes.Remove(productionPhoto);
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
