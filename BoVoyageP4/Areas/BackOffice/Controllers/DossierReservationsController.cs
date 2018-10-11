using BoVoyageP4.Controllers;
using BoVoyageP4.Filters;
using BoVoyageP4.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    [Authentication]
    public class DossierReservationsController : BaseController
    {
        // GET: BackOffice/DossierReservations
        public ActionResult Index()
        {
            var dossierReservations = db.DossierReservations.Include(d => d.Client).Include(d => d.Voyage);
            return View(dossierReservations.ToList());
        }

        // GET: BackOffice/DossierReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossierReservation dossierReservation = db.DossierReservations.Find(id);
            if (dossierReservation == null)
            {
                return HttpNotFound();
            }
            return View(dossierReservation);
        }

        // GET: BackOffice/DossierReservations/Create
        public ActionResult Create()
        {
            ViewBag.IDClient = new SelectList(db.Clients, "ID", "Email");
            ViewBag.IDVoyage = new SelectList(db.Voyages, "ID", "ID");
            return View();
        }

        // POST: BackOffice/DossierReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NumeroCarteBancaire,PrixParPersonne,EtatDossierReservation,RaisonAnnulationDossier,PrixTotal,IDVoyage,IDClient")] DossierReservation dossierReservation)
        {
            if (ModelState.IsValid)
            {
                db.DossierReservations.Add(dossierReservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDClient = new SelectList(db.Clients, "ID", "Email", dossierReservation.IDClient);
            ViewBag.IDVoyage = new SelectList(db.Voyages, "ID", "ID", dossierReservation.IDVoyage);
            return View(dossierReservation);
        }

        // GET: BackOffice/DossierReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossierReservation dossierReservation = db.DossierReservations.Find(id);
            if (dossierReservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClient = new SelectList(db.Clients, "ID", "Email", dossierReservation.IDClient);
            ViewBag.IDVoyage = new SelectList(db.Voyages, "ID", "ID", dossierReservation.IDVoyage);
            return View(dossierReservation);
        }

        // POST: BackOffice/DossierReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NumeroCarteBancaire,PrixParPersonne,EtatDossierReservation,RaisonAnnulationDossier,PrixTotal,IDVoyage,IDClient")] DossierReservation dossierReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dossierReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDClient = new SelectList(db.Clients, "ID", "Email", dossierReservation.IDClient);
            ViewBag.IDVoyage = new SelectList(db.Voyages, "ID", "ID", dossierReservation.IDVoyage);
            return View(dossierReservation);
        }

        // GET: BackOffice/DossierReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossierReservation dossierReservation = db.DossierReservations.Find(id);
            if (dossierReservation == null)
            {
                return HttpNotFound();
            }
            return View(dossierReservation);
        }

        // POST: BackOffice/DossierReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DossierReservation dossierReservation = db.DossierReservations.Find(id);
            db.DossierReservations.Remove(dossierReservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}