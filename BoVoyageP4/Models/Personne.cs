using BoVoyageP4.Enumeration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageP4.Models
{
    public abstract class Personne
    {
        public int ID { get; set; }

        [Required]
        public Civilite Civilite { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le nom doit contenir entre 1 et 40 caractères")]
        public string Nom { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le prenom doit contenir entre 1 et 40 caractères")]
        public string Prenom { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "L'adresse doit contenir entre 1 et 100 caractères")]
        public string Adresse { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le numéro doit contenir entre 1 et 40 caractères")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name = "Date de Naissance")]
        public DateTime DateNaissance { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DateNaissance.Year;
                return age;
            }
        }
    }
}