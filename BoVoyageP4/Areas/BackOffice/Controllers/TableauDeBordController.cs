using BoVoyageP4.Controllers;
using BoVoyageP4.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    [Authentication]
    public class TableauDeBordController : BaseController
    {
        // GET: BackOffice/TableauDeBord
        public ActionResult Index()
        {
            return View();
        }
    }
}