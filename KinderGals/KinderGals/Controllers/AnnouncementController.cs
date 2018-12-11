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
    public class AnnouncementController : Controller
    {
        private KGEntities db = new KGEntities();

        // GET: Announcement
        public ActionResult Announcements()
        {
            return View(db.Announces.ToList());
        }

       

        // GET: Announcement/Create
        public ActionResult Upload()
        {
            return View();
        }

        // POST: Announcement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload([Bind(Include = "AnnouncementID,Announcement,Date_Time")] Announce announce)
        {
            if (ModelState.IsValid)
            {
                db.Announces.Add(announce);
                db.SaveChanges();
                return RedirectToAction("Announcements");
            }

            return View(announce);
        }

        // GET: Announcement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announce announce = db.Announces.Find(id);
            if (announce == null)
            {
                return HttpNotFound();
            }
            return View(announce);
        }

        // POST: Announcement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnnouncementID,Announcement,Date_Time")] Announce announce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(announce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Announcements");
            }
            return View(announce);
        }

        // GET: Announcement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announce announce = db.Announces.Find(id);
            if (announce == null)
            {
                return HttpNotFound();
            }
            return View(announce);
        }

        // POST: Announcement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announce announce = db.Announces.Find(id);
            db.Announces.Remove(announce);
            db.SaveChanges();
            return RedirectToAction("Announcements");
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
