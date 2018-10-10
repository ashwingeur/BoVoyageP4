using BoVoyageP4.Enumeration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageP4.Models
{
    public class DossierReservation
    {
        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        public string NumeroCarteBancaire { get; set; }

        public decimal PrixParPersonne { get; set; }

        [Required]
        public Etat EtatDossierReservation { get; set; }

        public RaisonAnnulationDossier RaisonAnnulationDossier { get; set; }

        public decimal PrixTotal { get; set; }

        public int IDVoyage { get; set; }

        [ForeignKey("IDVoyage")]
        public Voyage Voyage { get; set; }

        public int IDClient { get; set; }

        [ForeignKey("IDClient")]
        public Client Client { get; set; }

        public List<Participant> Participants { get; set; }

        public List<Assurance> Assurances { get; set; }

        public DossierReservation()
        {
        }

        public DossierReservation(string ncb, decimal prix, Voyage v, Client c)
        {
            NumeroCarteBancaire = ncb;
            PrixParPersonne = prix;
            Voyage = v;
            Client = c;
            EtatDossierReservation = Etat.EnAttente;
        }

        public DossierReservation(string ncb, decimal prix, Voyage v, Client c, List<Participant> p_s)
        {
            NumeroCarteBancaire = ncb;
            PrixParPersonne = prix;
            Voyage = v;
            Client = c;
            Participants = p_s;
            EtatDossierReservation = Etat.EnAttente;
        }

        private void Annuler(RaisonAnnulationDossier raison)
        {
            RaisonAnnulationDossier = raison;
            EtatDossierReservation = Etat.Refusee;
        }

        private void ValiderSolvabiliter()
        {
            EtatDossierReservation = Etat.EnCours;
        }

        private void Accepter()
        {
            EtatDossierReservation = Etat.Acceptee;
        }
    }
}