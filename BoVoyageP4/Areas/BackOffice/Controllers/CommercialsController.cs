using BoVoyageP4.Controllers;
using BoVoyageP4.Filters;
using BoVoyageP4.Models;
using BoVoyageP4.Outils;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    [Authentication]
    public class CommercialsController : BaseController
    {
        // GET: BackOffice/Commercials
        public ActionResult Index()
        {
            return View(db.Commercials.ToList());
        }

        // GET: BackOffice/Commercials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commercial commercial = db.Commercials.Find(id);
            if (commercial == null)
            {
                return HttpNotFound();
            }
            return View(commercial);
        }

        // GET: BackOffice/Commercials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Commercials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Login,MotDePasse,MotDePasseVerification,Civilite,Nom,Prenom,Adresse,Telephone,DateNaissance")] Commercial commercial)
        {
            //commerciale.Login = commerciale.Nom.Substring(0, 2) + commerciale.Prenom.Substring(0, 2) + commerciale.ID.ToString();
            if (ModelState.IsValid)
            {
                commercial.MotDePasse = commercial.MotDePasse.HashMD5();
                commercial.MotDePasseVerification = commercial.MotDePasseVerification.HashMD5();

                db.Configuration.ValidateOnSaveEnabled = false;
                db.Commercials.Add(commercial);
                db.SaveChanges();

                db.Configuration.ValidateOnSaveEnabled = true;
                Display("Commercial enregistré");

                return RedirectToAction("index", "TableauDeBord");
            }

            return View(commercial);
        }

        // GET: BackOffice/Commercials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commercial commercial = db.Commercials.Find(id);
            if (commercial == null)
            {
                return HttpNotFound();
            }
            return View(commercial);
        }

        // POST: BackOffice/Commercials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commercial commercial = db.Commercials.Find(id);
            db.Commercials.Remove(commercial);
            db.SaveChanges();
            Display("Commercial effacé");
            return RedirectToAction("Index");
        }
    }
}