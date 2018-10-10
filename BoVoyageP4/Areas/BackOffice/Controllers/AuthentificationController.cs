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
    public class AuthentificationController : BaseController
    {
        // GET: BackOffice/Authentification
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthentificationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hash = model.Password.HashMD5();
                var admin = db.Commercials.SingleOrDefault(
                    x => x.Login == model.Login && x.MotDePasse == hash);

                if (admin == null)
                {
                    ModelState.AddModelError("Login", "Login / mot de passe invalide");
                    return View();
                }
                else
                {
                    Session["COMMERCIAL"] = admin;
                    return RedirectToAction("Index", "Dashboard", new { area = "backoffice" });
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("COMMERCIAL");
            return RedirectToAction("index", "home", new { area = "" });
        }

    }
}

