using BoVoyageP4.Controllers;
using BoVoyageP4.Filters;
using BoVoyageP4.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    
    public class FormulaireContactsController : BaseController
    {
        // GET: BackOffice/FormulaireContacts
        [Authentication]
        public ActionResult Index()
        {
            return View(db.FormulaireContacts.ToList());
        }

        // GET: BackOffice/FormulaireContacts/Details/5
        [Authentication]
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
        [Authentication]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/FormulaireContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authentication]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,Telephone,Question")] FormulaireContact formulaireContact)
        {
            if (ModelState.IsValid)
            {
                db.FormulaireContacts.Add(formulaireContact);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(formulaireContact);
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("~Views/FormulaireContact/Contact")]
        public ActionResult Contact([Bind(Include = "ID,Email,Telephone,Question")] FormulaireContact formulaireContact)
        {
            if (ModelState.IsValid)
            {
                db.FormulaireContacts.Add(formulaireContact);
                db.SaveChanges();
                Display("Question envoyée merci pour votre interet pour BoVoyage. Vous serez contacté bientot.");
                return RedirectToAction("Index", "Home");
            }

            return View(formulaireContact);
        }

        // GET: BackOffice/FormulaireContacts/Edit/5
        [Authentication]
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
        [Authentication]
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
        [Authentication]
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
        [Authentication]
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