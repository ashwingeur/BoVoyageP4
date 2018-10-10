﻿using BoVoyageP4.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BoVoyageP4.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "Accueil";
            ListeVoyageHome model = new ListeVoyageHome();
            model.Voyages = db.Voyages.Include("Destination")
                                              .Include("VoyageImage")
                                              .Where(x => x.DateAller >= DateTime.Now)
                                              .OrderBy(x => x.DateAller)
                                              .Take(5);
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