using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoVoyageP4.Models
{
    public class Destination
    {
        public int ID { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le nom du continent doit contenir entre 1 et 40 caractères")]
        public string Continent { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le nom du pays doit contenir entre 1 et 40 caractères")]
        public string Pays { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le nom de la region doit contenir entre 1 et 40 caractères")]
        public string Region { get; set; }

        public string Description { get; set; }

        public List<Voyage> Voyages { get; set; }

        public Destination() { }

        public Destination(string continent, string pays, string region)
        {
            Continent = continent;
            Pays = pays;
            Region = region;
        }

        public override string ToString()
        {
            return $"{Pays} : {Region}";
        }
    }
}