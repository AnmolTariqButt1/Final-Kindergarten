using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KinderGals.Models;

namespace KinderGals.Controllers
{
    public class AssignesController : Controller
    {
        private KGEntities db = new KGEntities();

        // GET: Assignes
        public ActionResult Assignments()
        {
            return View(db.Assignes.ToList());
        }

        // GET: Assignes/Create
        public ActionResult Upload()
        {
            return View();
        }

        // POST: Assignes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload([Bind(Include = "AssignmentID,Assignment,Date_Time")] Assigne assigne)
        {
            if (ModelState.IsValid)
            {
                db.Assignes.Add(assigne);
                db.SaveChanges();
                return RedirectToAction("Assignments");
            }

            return View(assigne);
        }

        // GET: Assignes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assigne assigne = db.Assignes.Find(id);
            if (assigne == null)
            {
                return HttpNotFound();
            }
            return View(assigne);
        }

        // POST: Assignes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentID,Assignment,Date_Time")] Assigne assigne)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assigne).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Assignments");
            }
            return View(assigne);
        }

        // GET: Assignes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assigne assigne = db.Assignes.Find(id);
            if (assigne == null)
            {
                return HttpNotFound();
            }
            return View(assigne);
        }

        // POST: Assignes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assigne assigne = db.Assignes.Find(id);
            db.Assignes.Remove(assigne);
            db.SaveChanges();
            return RedirectToAction("Assignments");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
