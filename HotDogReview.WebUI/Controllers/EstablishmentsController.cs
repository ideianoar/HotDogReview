using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotDogReview.Core.Geocoding;
using HotDogReview.WebUI.Models;
using HotDogReview.WebUI.ViewModels;

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
        public ActionResult Create(NewEstablishmentViewModel viewModel)
        {
            viewModel.Establishment.CreatedDateTime = DateTime.Now;

            // Geocodes the address.
            try
            {
                var geocoder = new GoogleGeocodingService();
                var coords = geocoder.GetCoordinate(viewModel.Establishment.Address);
				viewModel.Establishment.Latitude = coords.Latitude;
				viewModel.Establishment.Longitude = coords.Longitude;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível localizar o endereço. Detalhes: " + ex.Message);
            }

            if (ModelState.IsValid)
            {
				if (ExistsEstablishment(viewModel.Establishment.Name))
				{
					ModelState.AddModelError("", string.Format("O Estabelecimento \"{0}\" já está cadastrado", viewModel.Establishment.Name));
					return View(viewModel);
				}

                db.Establishments.Add(viewModel.Establishment);
                db.SaveChanges();

				viewModel.Review.EstablishmentId = viewModel.Establishment.Id;
				viewModel.Review.CreatedDateTime = DateTime.Now;

				db.Reviews.Add(viewModel.Review);
				db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

		private bool ExistsEstablishment(string name)
		{
			return db.Establishments.FirstOrDefault(entity => entity.Name.Equals(name.Trim(), StringComparison.InvariantCultureIgnoreCase)) != null;
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
            // Geocodes the address.
            try
            {
                var geocoder = new GoogleGeocodingService();
                var coords = geocoder.GetCoordinate(establishment.Address);
                establishment.Latitude = coords.Latitude;
                establishment.Longitude = coords.Longitude;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível localizar o endereço. Detalhes: " + ex.Message);
            }

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