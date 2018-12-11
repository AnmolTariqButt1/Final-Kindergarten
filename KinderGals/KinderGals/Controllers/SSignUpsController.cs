using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KinderGals.Models;

namespace KinderGals.Controllers
{
    public class SSignUpsController : Controller
    {
        private KGEntities db = new KGEntities();

        // GET: SSignUps
        public ActionResult Index()
        {
            return View(db.SSignUps.ToList());
        }

        
        // GET: SSignUps/Create
        public ActionResult SSignUp()
        {
            return View();
        }

        // POST: SSignUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SSignUp([Bind(Include = "ID,UserID,Name,ConfirmPassword,Password,Section")] SSignUp signUp)
        {
            {
                try
                {
                    SSignUp user = db.SSignUps.FirstOrDefault(u => u.UserID == (signUp.UserID));
                    if (user != null)
                        ModelState.AddModelError("UserID", "This User is already Registered");
                    if (ModelState.IsValid && user == null)
                    {
                        db.SSignUps.Add(signUp);
                        db.SaveChanges();
                        return RedirectToAction("StudentDashBoard");

                    }
                }

                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
                return View(signUp);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(SSignUp entity)
        {
            using (KGEntities db = new KGEntities())
            {
                SSignUp user = db.SSignUps.FirstOrDefault(u => u.UserID == (entity.UserID));
                TSignUp teacher = db.TSignUps.FirstOrDefault(t => t.UserID == (entity.UserID));
                ASignUp admin = db.ASignUps.FirstOrDefault(a => a.UserID == (entity.UserID));

                if (user == null || teacher == null || admin == null)
                {
                    TempData["ErrorMessage"] = "Object not found";
                    return View(entity);
                }

                int c = entity.Password.Count();
                if (user.Password.Substring(0, c) != entity.Password || teacher.Password.Substring(0, c) != entity.Password || admin.Password.Substring(0, c) != entity.Password)
                {
                    TempData["ErrorMessage"] = "Password do not Match";
                    return View(entity);
                }

                if (user != null || teacher != null || admin != null)
                {
                    if (user.Password.Substring(0, c) == entity.Password)

                        return RedirectToAction("StudentDashBoard");

                   
                    if (teacher.Password.Substring(0, c) == entity.Password)
                        return RedirectToAction("TeacherDashBoard", "TSignUp");
                    

                    if (admin.Password.Substring(0, c) == entity.Password)
                        return RedirectToAction("AdminDashBoard", "ASignUp");
                   
                    return View(entity);
                }
                return View(entity);
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
    
        public ActionResult StudentDashBoard()
        {
            return View();
        }

        


        // GET: General
        public ActionResult StudentProfile()
        {
            return View();
        }

        public ActionResult StudentMessages()
        {
            return View();
        }
        public ActionResult StudentNotifications()
        {
            return View();

        }

      

        public ActionResult LogOff()
        {
            return View();
        }

        public ActionResult Assignments()
        {
            return View(db.Assignes.ToList());
        }

        public ActionResult Announcements()
        {
            return View(db.Announces.ToList());
        }

        public ActionResult StudentList()
        {
            return View();
        }

        public ActionResult TeacherList()
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

