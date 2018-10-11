using BoVoyageP4.Controllers;
using BoVoyageP4.Filters;
using BoVoyageP4.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    [Authentication]
    public class VoyagesController : BaseController
    {
        // GET: BackOffice/Voyages
        public ActionResult Index()
        {
            var voyages = db.Voyages.Include(v => v.AgenceVoyage).Include(v => v.Destination).Include(v => v.Images);
            return View(voyages.ToList());
        }

        // GET: BackOffice/Voyages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // GET: BackOffice/Voyages/Create
        public ActionResult Create()
        {
            ViewBag.IDAgenceVoyage = new SelectList(db.AgencesVoyages, "ID", "Nom");
            ViewBag.IDDestination = new SelectList(db.Destinations, "ID", "Continent");
            return View();
        }

        // POST: BackOffice/Voyages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateAller,DateRetour,PlacesDisponibles,PrixParPersonne,IDDestination,IDAgenceVoyage")] Voyage voyage)
        {
            if (ModelState.IsValid)
            {
                db.Voyages.Add(voyage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDAgenceVoyage = new SelectList(db.AgencesVoyages, "ID", "Nom", voyage.IDAgenceVoyage);
            ViewBag.IDDestination = new SelectList(db.Destinations, "ID", "Continent", voyage.IDDestination);
            return View(voyage);
        }

        // GET: BackOffice/Voyages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Voyage voyage = db.Voyages.Include("Images").SingleOrDefault(x => x.ID == id); 

            if (voyage == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDAgenceVoyage = new SelectList(db.AgencesVoyages, "ID", "Nom", voyage.IDAgenceVoyage);
            ViewBag.IDDestination = new SelectList(db.Destinations, "ID", "Continent", voyage.IDDestination);
            return View(voyage);
        }

        // POST: BackOffice/Voyages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DateAller,DateRetour,PlacesDisponibles,PrixParPersonne,IDDestination,IDAgenceVoyage,Images")] Voyage voyage)
        {
            db.Voyages.Include("Images"); ;
            if (ModelState.IsValid)
            {
                db.Entry(voyage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDAgenceVoyage = new SelectList(db.AgencesVoyages, "ID", "Nom", voyage.IDAgenceVoyage);
            ViewBag.IDDestination = new SelectList(db.Destinations, "ID", "Continent", voyage.IDDestination);
            return View(voyage);
        }

        // GET: BackOffice/Voyages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // POST: BackOffice/Voyages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voyage voyage = db.Voyages.Find(id);
            db.Voyages.Remove(voyage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AjoutImage(HttpPostedFileBase image, int id)
        {
            if (image?.ContentLength > 0)
            {
                var img = new VoyageImage();
                img.ContentType = image.ContentType;
                img.Name = image.FileName;
                img.VoyageID = id;

                using (var reader = new BinaryReader(image.InputStream))
                {
                    img.Content = reader.ReadBytes(image.ContentLength);
                }

                db.VoyageImages.Add(img);
                db.SaveChanges();

                return RedirectToAction("edit", "voyages", new { id });
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult SupprimerImage(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var image = db.VoyageImages.Find(id);

            if (image == null)
                return HttpNotFound();

            db.VoyageImages.Remove(image);
            db.SaveChanges();
            return Json(image);
        }
    }
}