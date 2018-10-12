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

        public ActionResult Contact()
        {
            ViewBag.Message = "Votre page de contact";

            return View();
        }
    }
}