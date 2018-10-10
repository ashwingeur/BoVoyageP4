using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageP4.Data;
using BoVoyageP4.Models;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    public class AgenceVoyagesController : Controller
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: BackOffice/AgenceVoyages
        public ActionResult Index()
        {
            return View(db.AgencesVoyages.ToList());
        }

        // GET: BackOffice/AgenceVoyages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenceVoyage agenceVoyage = db.AgencesVoyages.Find(id);
            if (agenceVoyage == null)
            {
                return HttpNotFound();
            }
            return View(agenceVoyage);
        }

        // GET: BackOffice/AgenceVoyages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/AgenceVoyages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom")] AgenceVoyage agenceVoyage)
        {
            if (ModelState.IsValid)
            {
                db.AgencesVoyages.Add(agenceVoyage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agenceVoyage);
        }

        // GET: BackOffice/AgenceVoyages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenceVoyage agenceVoyage = db.AgencesVoyages.Find(id);
            if (agenceVoyage == null)
            {
                return HttpNotFound();
            }
            return View(agenceVoyage);
        }

        // POST: BackOffice/AgenceVoyages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom")] AgenceVoyage agenceVoyage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenceVoyage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agenceVoyage);
        }

        // GET: BackOffice/AgenceVoyages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenceVoyage agenceVoyage = db.AgencesVoyages.Find(id);
            if (agenceVoyage == null)
            {
                return HttpNotFound();
            }
            return View(agenceVoyage);
        }

        // POST: BackOffice/AgenceVoyages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgenceVoyage agenceVoyage = db.AgencesVoyages.Find(id);
            db.AgencesVoyages.Remove(agenceVoyage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
