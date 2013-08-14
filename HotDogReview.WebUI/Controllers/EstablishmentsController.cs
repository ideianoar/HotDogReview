using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotDogReview.WebUI.Models;

namespace HotDogReview.WebUI.Controllers
{
    public class EstablishmentsController : Controller
    {
        // Fields.
        private HotDogReviewEntities db = new HotDogReviewEntities();

        // Actions.
        public ActionResult Index()
        {
            return View(db.Establishments.ToList());
        }
        public ActionResult Details(int id = 0)
        {
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return HttpNotFound();
            }
            return View(establishment);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Establishment establishment)
        {
            establishment.CreatedDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Establishments.Add(establishment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(establishment);
        }
        public ActionResult Edit(int id = 0)
        {
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return HttpNotFound();
            }
            return View(establishment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Establishment establishment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(establishment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(establishment);
        }
        public ActionResult Delete(int id = 0)
        {
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return HttpNotFound();
            }
            return View(establishment);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Establishment establishment = db.Establishments.Find(id);
            db.Establishments.Remove(establishment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // IDisposable methods.
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}