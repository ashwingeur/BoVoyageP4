using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageP4.Models
{
    public class TableauDeBord
    {
        public List<Voyage> Voyage { get; set; }
        public List<DossierReservation> DossierReservation { get; set; }
    }
}