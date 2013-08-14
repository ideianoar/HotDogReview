using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotDogReview.WebUI.Models
{
	[MetadataType(typeof(ReviewMetadata))]
	public partial class Review
	{

	}

	public class ReviewMetadata
	{
		public double Rating { get; set; }
		public string ReviewText { get; set; }
	}
}