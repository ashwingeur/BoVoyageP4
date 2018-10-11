using BoVoyageP4.Controllers;
using BoVoyageP4.Filters;
using BoVoyageP4.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BoVoyageP4.Areas.BackOffice.Controllers
{
    [Authentication]
    public class AssurancesController : BaseController
    {
        // GET: BackOffice/Assurances
        public ActionResult Index()
        {
            return View(db.Assurances.ToList());
        }

        // GET: BackOffice/Assurances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assurance assurance = db.Assurances.Find(id);
            if (assurance == null)
            {
                return HttpNotFound();
            }
            return View(assurance);
        }

        // GET: BackOffice/Assurances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Assurances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TypeAssurance,Montant")] Assurance assurance)
        {
            if (ModelState.IsValid)
            {
                db.Assurances.Add(assurance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assurance);
        }

        // GET: BackOffice/Assurances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assurance assurance = db.Assurances.Find(id);
            if (assurance == null)
            {
                return HttpNotFound();
            }
            return View(assurance);
        }

        // POST: BackOffice/Assurances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TypeAssurance,Montant")] Assurance assurance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assurance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assurance);
        }

        // GET: BackOffice/Assurances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assurance assurance = db.Assurances.Find(id);
            if (assurance == null)
            {
                return HttpNotFound();
            }
            return View(assurance);
        }

        // POST: BackOffice/Assurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assurance assurance = db.Assurances.Find(id);
            db.Assurances.Remove(assurance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}