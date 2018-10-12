using BoVoyageP4.Models;
using System.Collections.Generic;
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
            Session["Voyage"] = db.Voyages.Include(x => x.AgenceVoyage).Include(x => x.Destination).SingleOrDefault(x => x.ID == id);
            ViewBag.Assurances = new SelectList(db.Assurances, "ID", "Montant");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservation([Bind(Include = "ID,NumeroCarteBancaire,PrixParPersonne,EtatDossierReservation,RaisonAnnulationDossier,PrixTotal,IDVoyage,IDClient")] DossierReservation dossierReservation, Assurance Assurance, int? nbParticipants)
        {
            if (ModelState.IsValid)
            {
                dossierReservation.Assurances = new List<Assurance>();
                dossierReservation.Assurances.Add(Assurance);
                dossierReservation.PrixTotal = Assurance.Montant;
                db.DossierReservations.Add(dossierReservation);
                db.SaveChanges();
                Session["IDDossier"] = dossierReservation.ID;
                Session["Participants"] = nbParticipants;
                return RedirectToAction("Ajout");
            }
            ViewBag.Assurances = new SelectList(db.Assurances, "ID", "Nom", dossierReservation.Assurances);
            ViewBag.IDClient = new SelectList(db.Clients, "ID", "Email", dossierReservation.IDClient);
            ViewBag.IDVoyage = new SelectList(db.Voyages, "ID", "ID", dossierReservation.IDVoyage);
            return View(dossierReservation);
        }

        public ActionResult Ajout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ajout(List<Participant> participants)
        {
            if (participants != null)
            {
                if (ModelState.IsValid)
                {
                    foreach (Participant participant in participants)
                    {
                        if (ModelState.IsValid)
                        {
                            participant.IDDossierReservation = int.Parse(Session["IDDossier"].ToString());
                            db.Participants.Add(participant);
                            db.SaveChanges();

                            var dossier = db.DossierReservations.Include(x => x.Assurances).Include(x => x.Voyage).SingleOrDefault(x => x.ID == participant.IDDossierReservation);
                            dossier.Participants.Add(participant);
                            dossier.PrixTotal += dossier.PrixParPersonne * (decimal)participant.Reduction;
                            dossier.Voyage.PlacesDisponibles--;
                            db.Entry(dossier).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            return View(participant);
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var dossier = db.DossierReservations.Find(int.Parse(Session["IDDossier"].ToString()));
                    db.DossierReservations.Remove(dossier);
                    db.SaveChanges();
                    return View(participants);
                }
            }
            else
            {
                var dossier = db.DossierReservations.Find(int.Parse(Session["IDDossier"].ToString()));
                db.DossierReservations.Remove(dossier);
                db.SaveChanges();
                return View(participants);
            }
        }
    }
}