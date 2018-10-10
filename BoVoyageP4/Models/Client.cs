using BoVoyageP4.Enumeration;
using BoVoyageP4.Validateurs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageP4.Models
{
    public class Client : Personne
    {
        [StringLength(150, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
        [Display(Name = "Adresse mail")]
        /*[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
            , ErrorMessage = "Le format n'est pas bon.")]*/
        [Index(IsUnique = true)]
        [Email]
        public string Email { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.")]
        /*[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "{0} incorrect.")]*/
        [StringLength(150)]
        public string MotDePasse { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("MotDePasse", ErrorMessage = "La confirmation n'est pas bonne.")]
        [NotMapped]
        public string MotDePasseVerification { get; set; }

        public Client()
        {
        }

        public Client(Civilite civilite, string nom, string prenom, string adresse, string telephone, DateTime dateNaissance)
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