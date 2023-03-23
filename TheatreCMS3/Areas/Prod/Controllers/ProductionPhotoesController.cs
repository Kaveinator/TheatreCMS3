using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Models;
using TheatreCMS3.Models;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Web;
namespace TheatreCMS3.Areas.Prod.Controllers
{
    public class ProductionPhotoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prod/ProductionPhotoes
        public ActionResult Index()
        {
            return View(db.ProductionPhotos.ToList());
        }

        // GET: Prod/ProductionPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProPhotoId,Title,Description")] ProductionPhoto productionPhoto, HttpPostedFileBase uploadedImage)
        {
            if (ModelState.IsValid)
            {
                
                if (uploadedImage != null)
                {
                    // Convert the uploaded image to a byte array and assign it to the ProductionPhoto Instance
                    productionPhoto.PhotoFile = ConvertImageToByteArray(uploadedImage);
                }
                
                db.ProductionPhotos.Add(productionPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionPhoto);
        }


        // GET: Prod/ProductionPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
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
        public ActionResult Edit(int id, [Bind(Include = "ProPhotoId,Title,Description")] ProductionPhoto productionPhoto, HttpPostedFileBase uploadedImage)
        {
            if (id != productionPhoto.ProPhotoId)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (uploadedImage != null)
                    {
                        // Convert the uploaded image to a byte array and assign it to the ProductionPhoto instance
                        productionPhoto.PhotoFile = ConvertImageToByteArray(uploadedImage);
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionPhotoExists(productionPhoto.ProPhotoId))
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
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
            ProductionPhoto productionPhoto = db.ProductionPhotos.Find(id);
            db.ProductionPhotos.Remove(productionPhoto);
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

        private byte[] ConvertImageToByteArray(HttpPostedFileBase uploadedImage)
        {
            if (uploadedImage != null && uploadedImage.ContentLength > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    uploadedImage.InputStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }

            return null;
        }

        private bool ProductionPhotoExists(int id)
        {
            return db.ProductionPhotos.Any(e => e.ProPhotoId == id);
        }

    }
}
