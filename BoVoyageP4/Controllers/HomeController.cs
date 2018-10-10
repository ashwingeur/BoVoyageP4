using BoVoyageP4.Models;
using System;
using System.Web.Mvc;

namespace BoVoyageP4.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "Accueil";
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.Tournaments = db.Tournaments.Include("Weapons")
                                              .Include("Pictures")
                                              .Where(x => x.StartDate >= DateTime.Now)
                                              .OrderBy(x => x.StartDate)
                                              .Take(20);
            return View(model);
        }

        //[Route("a-propos")]
        public ActionResult About()
        {
            var modelInfo = new Info
            {
                NomDeveloppeur = "TEAM LAS",
                ContactMail = "contact@teamlas.com",
                DateCreation = DateTime.Now
            };
            return View(modelInfo);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}