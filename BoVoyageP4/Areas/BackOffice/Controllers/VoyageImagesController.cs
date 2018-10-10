using BoVoyageP4.Controllers;
using BoVoyageP4.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    public class VoyageImagesController : BaseController
    {
        // GET: BackOffice/VoyageImages
        public ActionResult Index()
        {
            var voyageImage = db.VoyageImages.Include(v => v.Voyage);
            return View(voyageImage.ToList());
        }

        // GET: BackOffice/VoyageImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoyageImage voyageImage = db.VoyageImages.Find(id);
            if (voyageImage == null)
            {
                return HttpNotFound();
            }
            return View(voyageImage);
        }

        // GET: BackOffice/VoyageImages/Create
        public ActionResult Create()
        {
            ViewBag.VoyageID = new SelectList(db.Voyages, "ID", "ID");
            return View();
        }

        // POST: BackOffice/VoyageImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ContentType,Content,VoyageID")] VoyageImage voyageImage)
        {
            if (ModelState.IsValid)
            {
                db.VoyageImages.Add(voyageImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VoyageID = new SelectList(db.Voyages, "ID", "ID", voyageImage.VoyageID);
            return View(voyageImage);
        }

        // GET: BackOffice/VoyageImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoyageImage voyageImage = db.VoyageImages.Find(id);
            if (voyageImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.VoyageID = new SelectList(db.Voyages, "ID", "ID", voyageImage.VoyageID);
            return View(voyageImage);
        }

        // POST: BackOffice/VoyageImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ContentType,Content,VoyageID")] VoyageImage voyageImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voyageImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VoyageID = new SelectList(db.Voyages, "ID", "ID", voyageImage.VoyageID);
            return View(voyageImage);
        }

        // GET: BackOffice/VoyageImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoyageImage voyageImage = db.VoyageImages.Find(id);
            if (voyageImage == null)
            {
                return HttpNotFound();
            }
            return View(voyageImage);
        }

        // POST: BackOffice/VoyageImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoyageImage voyageImage = db.VoyageImages.Find(id);
            db.VoyageImages.Remove(voyageImage);
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