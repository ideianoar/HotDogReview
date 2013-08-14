using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotDogReview.WebUI.Models;

namespace HotDogReview.WebUI.Controllers
{
    public class EstablishmentsApiController : ApiController
    {
        // Fields.
        private HotDogReviewEntities db = new HotDogReviewEntities();

        // IDisposable methods.
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
