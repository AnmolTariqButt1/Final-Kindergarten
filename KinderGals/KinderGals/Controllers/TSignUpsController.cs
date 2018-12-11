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
    public class TSignUpsController : Controller
    {
        private KGEntities db = new KGEntities();

        // GET: TSignUps
        public ActionResult Index()
        {
            return View(db.TSignUps.ToList());
        }


        // GET: SSignUps/Create
        public ActionResult TSignUp()
        {
            return View();
        }

        // POST: SSignUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TSignUp([Bind(Include = "ID,UserID,Name,Password,ConfirmPassword,SectionA, SectionB, SectionC")] TSignUp signUp)
        {
            {
                try
                {
                    TSignUp user = db.TSignUps.FirstOrDefault(u => u.UserID == (signUp.UserID));
                    if (user != null)
                        ModelState.AddModelError("UserID", "This User is already Registered");
                    if (ModelState.IsValid && user == null)
                    {
                        db.TSignUps.Add(signUp);
                        db.SaveChanges();
                        return RedirectToAction("TeacherDashBoard");
                    }
                }

                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
                return View(signUp);
            }
        }

        public ActionResult TeacherDashBoard()
        {
            return View();
        }

        public ActionResult TeacherMessages()
        {
            return View();
        }

        public ActionResult TeacherProfile()
        {
            return View();
        }

        public ActionResult TeacherNotifications()
        {
            return View();
        }

        public ActionResult StudentList()
        {
            return View();
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
