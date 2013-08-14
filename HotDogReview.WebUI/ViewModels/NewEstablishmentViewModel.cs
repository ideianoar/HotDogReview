using HotDogReview.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogReview.WebUI.ViewModels
{
	public class NewEstablishmentViewModel
	{
		public Establishment Establishment { get; set; }
		public Review Review { get; set; }
	}
}