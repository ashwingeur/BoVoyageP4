using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BoVoyageP4.Models
{
    public class AgenceVoyage
    {
        public int ID { get; set; }

        [Required]
        //[Index(IsUnique = true)]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le nom de l'agence doit contenir entre 1 et 40 caractères")]
        public string Nom { get; set; }


        public List<Voyage> Voyages { get; set; }

        //Implementation du constructeur par defaut nécéssaire à Entity
        public AgenceVoyage() { }

        public AgenceVoyage(string nom)
        {
            Nom = Nom;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}