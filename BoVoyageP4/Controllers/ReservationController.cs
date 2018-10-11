using BoVoyageP4.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BoVoyageP4.Controllers
{
    public class ReservationController : BaseController
    {
        // GET: Reservation
        public ActionResult Reservation(int id)
        {
            TempData["Voyage"] = db.Voyages.Include(x => x.AgenceVoyage).Include(x => x.Destination).SingleOrDefault(x => x.ID == id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservation([Bind(Include = "ID,NumeroCarteBancaire,PrixParPersonne,EtatDossierReservation,RaisonAnnulationDossier,PrixTotal,IDVoyage,IDClient")] DossierReservation dossierReservation)
        {
            if (ModelState.IsValid)
            {
                db.DossierReservations.Add(dossierReservation);
                db.SaveChanges();
                TempData["IDDossier"] = dossierReservation.ID;
                return RedirectToAction("Index", "home");
            }

            ViewBag.IDClient = new SelectList(db.Clients, "ID", "Email", dossierReservation.IDClient);
            ViewBag.IDVoyage = new SelectList(db.Voyages, "ID", "ID", dossierReservation.IDVoyage);
            return View(dossierReservation);
        }
    }
}