
using BoVoyageP4.Controllers;
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
    }
}