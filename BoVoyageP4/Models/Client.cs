using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageP4.Models
{
    public class Client : Personne
    {
        [Required]
        [Index(IsUnique = true)]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le nom du client doit contenir entre 1 et 40 caractères")]
        public string Email { get; set; }

        public Client()
        {
        }
        public Client(string civilite, string nom, string prenom, string adresse, string telephone, DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Civilite = civilite;
            Telephone = telephone;
            DateNaissance = dateNaissance;
        }

        public List<DossierReservation> DossierReservation { get; set; }
    }
}