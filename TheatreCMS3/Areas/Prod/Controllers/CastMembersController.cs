using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
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
        public ActionResult Create([Bind(Include = "CastMemberId,Name,YearJoined,MainRole,Photo,Bio,CurrentMember,Character,CastYearLeft,DebutYear")] CastMember castMember)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "CastMemberId,Name,YearJoined,MainRole,Photo,Bio,CurrentMember,Character,CastYearLeft,DebutYear")] CastMember castMember)
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

        public byte[] ImagetoByte(HttpPostedFileBase castMemberPhotoUpload)
        {
            byte[] CastMemberImage = null;
            BinaryReader br = new BinaryReader(castMemberPhotoUpload.InputStream);
            {
                CastMemberImage = br.ReadBytes(castMemberPhotoUpload.ContentLength);
            }
            return CastMemberImage;

            
            //string strFileName;
            //string strFilePath;
            //string strFolder;
            //strFolder = Server.MapPath("./");
            //strFileName = castMemberPhotoUpload.FileName;
            //strFileName = Path.GetFileName(strFileName);
            //if (castMemberPhotoUpload.FileName != "")
            //{
            //    // Create the folder if it does not exist.
            //    if (!Directory.Exists(strFolder))
            //    {
            //        Directory.CreateDirectory(strFolder);
            //    }
            //    // Save the uploaded file to the server.
            //    strFilePath = strFolder + strFileName;

            //if (File.Exists(strFilePath))
            //{
            //    lblUploadResult.Text = strFileName + " already exists on the server!";
            //}
            //else
            //{
            //    oFile.PostedFile.SaveAs(strFilePath);
            //    lblUploadResult.Text = strFileName + " has been successfully uploaded.";
            //}
            //}
            //else
            //{
            //    lblUploadResult.Text = "Click 'Browse' to select the file to upload.";
            //}


            //FilesEntities entities = new FilesEntities();
            //entities.CastMembers.Add(new CastMember
            //{

            //});
            //entities.SaveChanges();
            //return RedirectToAction("");
        }


    }   
    
}
