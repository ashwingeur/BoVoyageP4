using BoVoyageP4.Controllers;
using BoVoyageP4.Models;
using BoVoyageP4.Outils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    public class AuthentificationClientController : BaseController
    {
        // GET: AuthentificationClient
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthentificationEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hash = model.Password.HashMD5();
                var client = db.Clients.SingleOrDefault(
                    x => x.Email == model.Mail && x.MotDePasse == hash);

                if (client == null)
                {
                    ModelState.AddModelError("Mail", "Mail / mot de passe invalide");
                    return View();
                }
                else
                {
                    Session["CLIENT"] = client;
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("CLIENT");
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}

