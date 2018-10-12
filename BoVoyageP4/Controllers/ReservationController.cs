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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reservation([Bind(Include = "ID,NumeroCarteBancaire,PrixParPersonne,EtatDossierReservation,RaisonAnnulationDossier,PrixTotal,IDVoyage,IDClient")] DossierReservation dossierReservation, int? nbParticipants)
        {
            if (ModelState.IsValid)
            {
                db.DossierReservations.Add(dossierReservation);
                db.SaveChanges();
                Session["IDDossier"] = dossierReservation.ID;
                Session["Participants"] = nbParticipants;
                return RedirectToAction("Ajout");
            }

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
        public ActionResult Ajout([Bind(Include = "ID,IDDossierReservation,model[i].Civilite,model[i].Nom,model[i].Prenom,model[i].Adresse,model[i].Telephone,model[i].DateNaissance")] List<Participant> participants)
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

                            var dossier = db.DossierReservations.Find(participant.IDDossierReservation);
                            dossier.Participants.Add(participant);
                            dossier.PrixTotal += dossier.PrixParPersonne * (decimal)participant.Reduction;
                            db.Entry(dossier).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var dossier = db.DossierReservations.Find(int.Parse(Session["IDDossier"].ToString()));
                    db.DossierReservations.Remove(dossier);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}