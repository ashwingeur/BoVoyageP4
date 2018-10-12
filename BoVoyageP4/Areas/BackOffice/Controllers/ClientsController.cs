using BoVoyageP4.Controllers;
using BoVoyageP4.Filters;
using BoVoyageP4.Models;
using BoVoyageP4.Outils;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    public class ClientsController : BaseController
    {
        [Authentication]
        // GET: BackOffice/Clients
        public ActionResult Index()
        {
            return View(db.Clients.OrderBy(x => x.Nom).ToList());
        }

        [Authentication]
        public ActionResult Recherche(string Filter)
        {
            return View("Index", db.Clients.Where(x => x.Nom.Contains(Filter)).ToList());
        }

        [Authentication]
        public ActionResult Tri(string ChampsTri)
        {
            Display("Tri validé");

            switch (ChampsTri)
            {
                case "NOM":
                    return View("Index", db.Clients.OrderBy(x => x.Nom).ToList());
                case "CIVILITE":
                    return View("Index", db.Clients.OrderBy(x => x.Civilite).ToList());
                case "DATEDENAISSANCE":
                    return View("Index", db.Clients.OrderBy(x => x.DateNaissance).ToList());
                case "EMAIL":
                    return View("Index", db.Clients.OrderBy(x => x.Email).ToList());
                case "ORDREINSCRIPTION":
                    return View("Index", db.Clients.ToList());
                default:
                    return View("Index", db.Clients.OrderBy(x => x.Nom).ToList());
            }

        }


        [Authentication]
        // GET: BackOffice/Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: BackOffice/Clients/Create
        [Authentication]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create([Bind(Include = "ID,Email,MotDePasse,MotDePasseVerification,Civilite,Nom,Prenom,Adresse,Telephone,DateNaissance")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                Display("Client enregistré");
                return RedirectToAction("Index");
            }

            return View(client);
        }

        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route(Name = "~Views/Clients/Subscribe")]
        public ActionResult Subscribe([Bind(Include = "Email,MotDePasse,MotDePasseVerification,Civilite,Nom,Prenom,Adresse,Telephone,DateNaissance")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.MotDePasse = client.MotDePasse.HashMD5();
                client.MotDePasseVerification = client.MotDePasseVerification.HashMD5();

                db.Configuration.ValidateOnSaveEnabled = false;
                db.Clients.Add(client);
                db.SaveChanges();

                db.Configuration.ValidateOnSaveEnabled = true;
                Display("Client enregistré");

                return RedirectToAction("index", "home");
            }

            return View(client);
        }

        // GET: BackOffice/Clients/Edit/5
        [Authentication]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        // POST: BackOffice/Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Edit([Bind(Include = "ID,Email,MotDePasse,Civilite,Nom,Prenom,Adresse,Telephone,DateNaissance")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                Display("Client modifié");
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: BackOffice/Clients/Delete/5
        [Authentication]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: BackOffice/Clients/Delete/5
        [Authentication]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            Display("Client effacé");
            return RedirectToAction("Index");
        }
    }
}