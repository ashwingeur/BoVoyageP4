using BoVoyageP4.Controllers;
using BoVoyageP4.Filters;
using BoVoyageP4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    [Authentication]
    public class TableauDeBordController : BaseController
    {
        // GET: BackOffice/TableauDeBord
        public ActionResult Index()
        {
            var voyages = db.Voyages.Include("Destination").Where(x=>x.DateAller < DbFunctions.AddDays(DateTime.Now, 15)).ToList();
            var dossiers = db.DossierReservations.Include("Client").Where(x=>x.EtatDossierReservation == 0).ToList();
            TableauDeBord dashboard = new TableauDeBord()
            {
                Voyage = voyages,
                DossierReservation = dossiers
            };
            return View(dashboard);
        }
    }
}