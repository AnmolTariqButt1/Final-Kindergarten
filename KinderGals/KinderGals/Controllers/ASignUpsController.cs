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
    public class ASignUpsController : Controller
    {
        private KGEntities db = new KGEntities();

        // GET: ASignUps
        public ActionResult Index()
        {
            return View(db.ASignUps.ToList());
        }


        // GET: ASignUps/Create
        public ActionResult ASignUp()
        {
            return View();
        }

        // POST: ASignUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ASignUp([Bind(Include = "ID,UserID,Password,ConfirmPassword")] ASignUp signUp)
        {
            {
                try
                {
                    ASignUp user = db.ASignUps.FirstOrDefault(u => u.UserID == (signUp.UserID));
                    if (user != null)
                        ModelState.AddModelError("UserID", "This ID is already Registered");
                    if (ModelState.IsValid && user == null)
                    {
                        db.ASignUps.Add(signUp);
                        db.SaveChanges();
                        return RedirectToAction("AdminDashBoard");

                    }
                }

                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
                return View(signUp);
            }

        }

        public ActionResult AdminDashBoard()
        {
            return View();
        }

        public ActionResult StudentList()
        {
            return View(db.SSignUps.ToList());
        }

        public ActionResult TeacherList()
        {
            return View(db.TSignUps.ToList());
        }



        // GET: Announcement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASignUp user = db.ASignUps.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Announcement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Name,Email,Password,SectionA,SectionB,SectionC")] ASignUp user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminDashBoard");
            }
            return View(user);
        }

        // GET: Announcement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASignUp user = db.ASignUps.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Announcement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASignUp user = db.ASignUps.Find(id);
            db.ASignUps.Remove(user);
            db.SaveChanges();
            return RedirectToAction("AdminDashBoard");
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
