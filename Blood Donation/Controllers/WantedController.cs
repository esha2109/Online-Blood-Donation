using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blood_Donation.Models;

namespace Blood_Donation.Controllers
{
    public class WantedController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Wanted/

        public ActionResult Index()
        {
            return View(db.wanted.ToList());
        }

        //
        // GET: /Wanted/Details/5

        public ActionResult Details(int id = 0)
        {
            BloodWanted bloodwanted = db.wanted.Find(id);
            if (bloodwanted == null)
            {
                return HttpNotFound();
            }
            return View(bloodwanted);
        }

        //
        // GET: /Wanted/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Wanted/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BloodWanted bloodwanted)
        {
            if (ModelState.IsValid)
            {
                db.wanted.Add(bloodwanted);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodwanted);
        }

        //
        // GET: /Wanted/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BloodWanted bloodwanted = db.wanted.Find(id);
            if (bloodwanted == null)
            {
                return HttpNotFound();
            }
            return View(bloodwanted);
        }

        //
        // POST: /Wanted/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BloodWanted bloodwanted)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodwanted).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodwanted);
        }

        //
        // GET: /Wanted/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BloodWanted bloodwanted = db.wanted.Find(id);
            if (bloodwanted == null)
            {
                return HttpNotFound();
            }
            return View(bloodwanted);
        }

        //
        // POST: /Wanted/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodWanted bloodwanted = db.wanted.Find(id);
            db.wanted.Remove(bloodwanted);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}