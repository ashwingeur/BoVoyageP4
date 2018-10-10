using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageP4.Data;
using BoVoyageP4.Models;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    public class VoyageImagesController : Controller
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: BackOffice/VoyageImages
        public ActionResult Index()
        {
            var voyageImage = db.VoyageImage.Include(v => v.Voyage);
            return View(voyageImage.ToList());
        }

        // GET: BackOffice/VoyageImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoyageImage voyageImage = db.VoyageImage.Find(id);
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
                db.VoyageImage.Add(voyageImage);
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
            VoyageImage voyageImage = db.VoyageImage.Find(id);
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
            VoyageImage voyageImage = db.VoyageImage.Find(id);
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
            VoyageImage voyageImage = db.VoyageImage.Find(id);
            db.VoyageImage.Remove(voyageImage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
