using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotDogReview.WebUI.Models;

namespace HotDogReview.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // Fields.
        private HotDogReviewEntities db = new HotDogReviewEntities();

        // Actions.
        public ActionResult Index()
        {
            var model = db.Establishments
                .Include("Reviews")
                .ToList();

            return View(model);
        }

        // IDisposable methods.
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
