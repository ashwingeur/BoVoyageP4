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
    public class FormulaireContactsController : Controller
    {
        private BoVoyageDbContext db = new BoVoyageDbContext();

        // GET: BackOffice/FormulaireContacts
        public ActionResult Index()
        {
            return View(db.FormulaireContacts.ToList());
        }

        // GET: BackOffice/FormulaireContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormulaireContact formulaireContact = db.FormulaireContacts.Find(id);
            if (formulaireContact == null)
            {
                return HttpNotFound();
            }
            return View(formulaireContact);
        }

        // GET: BackOffice/FormulaireContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/FormulaireContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,Telephone,Question")] FormulaireContact formulaireContact)
        {
            if (ModelState.IsValid)
            {
                db.FormulaireContacts.Add(formulaireContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formulaireContact);
        }

        // GET: BackOffice/FormulaireContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormulaireContact formulaireContact = db.FormulaireContacts.Find(id);
            if (formulaireContact == null)
            {
                return HttpNotFound();
            }
            return View(formulaireContact);
        }

        // POST: BackOffice/FormulaireContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,Telephone,Question")] FormulaireContact formulaireContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formulaireContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formulaireContact);
        }

        // GET: BackOffice/FormulaireContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormulaireContact formulaireContact = db.FormulaireContacts.Find(id);
            if (formulaireContact == null)
            {
                return HttpNotFound();
            }
            return View(formulaireContact);
        }

        // POST: BackOffice/FormulaireContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormulaireContact formulaireContact = db.FormulaireContacts.Find(id);
            db.FormulaireContacts.Remove(formulaireContact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
