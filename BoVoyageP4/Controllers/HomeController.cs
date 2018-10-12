using BoVoyageP4.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
namespace BoVoyageP4.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "Accueil";
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Voyages = db.Voyages.Include(v => v.Destination).Include(v => v.Images);
            return View(model);
        }

        public ActionResult Recherche(string Filter)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Voyages = db.Voyages.Include(v => v.Destination).Include(v => v.Images).Where(x => x.Destination.Region.Contains(Filter)).ToList();

            return View("Index", model);
        }

        public ActionResult Tri(string ChampsTri)
        {
            Display("Tri validé");
            HomeIndexViewModel model = new HomeIndexViewModel();

            switch (ChampsTri)
            {
                case "REGION":
                    model.Voyages=db.Voyages.Include(v => v.Destination).OrderBy(x => x.Destination.Region).Include(v => v.Images).ToList();
                    break;
                case "DATEDEPART":
                    model.Voyages=db.Voyages.Include(v => v.Destination).OrderBy(x => x.DateAller).Include(v => v.Images).ToList();
                    break;
                case "DATERETOUR":
                    model.Voyages=db.Voyages.Include(v => v.Destination).OrderBy(x => x.DateRetour).Include(v => v.Images).ToList();
                    break;
                case "PLACESDISPONIBLES":
                    model.Voyages=db.Voyages.Include(v => v.Destination).OrderBy(x => x.PlacesDisponibles).Include(v => v.Images).ToList();
                    break;
                case "PRIX":
                    model.Voyages = db.Voyages.Include(v => v.Destination).OrderBy(x => x.PrixParPersonne).Include(v => v.Images).ToList();
                    break;
                default:
                    model.Voyages = db.Voyages.Include(v => v.Destination).OrderBy(x => x.Destination.Region).Include(v => v.Images).ToList();
                    break;
            }
            return View("Index", model);

        }


        // GET: Voyages/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Voyage voyage = db.Voyages.Find(id).Include(v => v.Destination).Include(v => v.Images);
            var voyage = db.Voyages.Include("Destination")
                                 .Include("Images")
                                 .SingleOrDefault(x => x.ID == id);

            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        public ActionResult About()
        {
            var modelInfo = new Info
            {
                NomDeveloppeur = "GTM Team",
                ContactMail = "ALS@GTM.FR",
                DateCreation = DateTime.Now
            };
            return View(modelInfo);
        }

       
    }
}