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
            model.Voyages = db.Voyages.Include(v => v.Destination);
                                         
            return View(model);
        }

        //[Route("a-propos")]
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