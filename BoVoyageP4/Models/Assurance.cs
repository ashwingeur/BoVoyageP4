using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BoVoyageP4.Enumeration;

namespace BoVoyageP4.Models
{
    public class Assurance
    {
        public int ID { get; set; }
        [Required]
        public TypeAssurance TypeAssurance { get; set; }
        public decimal Montant { get; set; }
        public List<DossierReservation> DossierReservations { get; set; }
    }
}