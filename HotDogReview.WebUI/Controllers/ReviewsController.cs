using HotDogReview.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotDogReview.WebUI.Controllers
{
    public class ReviewsController : Controller
    {
		// Fields.
		private HotDogReviewEntities db = new HotDogReviewEntities();

		// Actions.
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Create(int id)
		{
			Establishment establishment = db.Establishments.FirstOrDefault(entity => entity.Id == id);
			if (establishment == null)
				return RedirectToAction("Index", "Home");

			ViewBag.EstablishmentName = establishment.Name;
			Review review = new Review
			{
				EstablishmentId = id
			};

			return View(review);
		}
		[HttpPost]
		public ActionResult Create(Review review)
		{
			review.CreatedDateTime = DateTime.Now;

			if (ModelState.IsValid)
			{
				db.Reviews.Add(review);
				db.SaveChanges();

				return RedirectToAction("Index", "Home");
			}

			return View(review);
		}
    }
}
