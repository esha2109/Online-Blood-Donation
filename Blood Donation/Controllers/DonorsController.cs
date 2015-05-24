using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blood_Donation.Models;
using System.Web.Security;
using System.Data.Entity.Validation;

namespace Blood_Donation.Controllers
{
    public class DonorsController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Donors/

        public ActionResult Index()
        {
            return View(db.donor.ToList());
        }

        public ActionResult IndexUser()
        {
            return View(db.donor.ToList());
        }

        //
        // GET: /Donors/Details/5

        public ActionResult Details(int id = 0)
        {
            Donors donors = db.donor.Find(id);
            if (donors == null)
            {
                return HttpNotFound();
            }
            return View(donors);
        }

        //
        // GET: /Donors/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Donors/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Donors donors)
        {
            if (ModelState.IsValid)
            {
                db.donor.Add(donors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donors);
        }

        //
        // GET: /Donors/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Donors donors = db.donor.Find(id);
            if (donors == null)
            {
                return HttpNotFound();
            }
            return View(donors);
        }

        //
        // POST: /Donors/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Donors donors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donors);
        }

        //
        // GET: /Donors/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Donors donors = db.donor.Find(id);
            if (donors == null)
            {
                return HttpNotFound();
            }
            return View(donors);
        }

        //
        // POST: /Donors/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donors donors = db.donor.Find(id);
            db.donor.Remove(donors);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // Login functions
        // GET: /User/

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.Donors userr)
        {
            //if (ModelState.IsValid)
            //{
            if (IsValid(userr.email, userr.Password))
            {
                FormsAuthentication.SetAuthCookie(userr.email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login details are wrong.");
            }
            return View(userr);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.Donors user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new Blood_Donation.Models.Context())
                    {
                        var crypto = new SimpleCrypto.PBKDF2();
                        var encrypPass = crypto.Compute(user.Password);
                        var newUser = db.donor.Create();
                        newUser.email = user.email;
                        newUser.Password = encrypPass;
                        newUser.PasswordSalt = crypto.Salt;
                        newUser.Name = user.Name;
                        newUser.NID = user.NID;
                        newUser.Last_Donated = user.Last_Donated;
                        newUser.Address = user.Address;
                        newUser.Age = user.Age;
                        newUser.Area = user.Area;
                        newUser.Blood_Group = user.Blood_Group;
                        newUser.Contact_No = user.Contact_No;
                        db.donor.Add(newUser);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Data is not correct");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new Blood_Donation.Models.Context())
            {
                var user = db.donor.FirstOrDefault(u => u.email == email);
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        } 
    }
}