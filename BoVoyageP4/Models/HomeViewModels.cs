using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoVoyageP4.Models
{
    public class HomeIndexViewModel

    {
        public IEnumerable<Voyage> Voyages { get; set; }
    }
}