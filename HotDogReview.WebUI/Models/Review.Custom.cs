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
		[Display(Name="Nota da Avaliação")]
		[Required(ErrorMessage="Informe uma nota de avaliação para o HotDog")]
		[Range(1, 5, ErrorMessage = "Informe uma nota de avaliação para o HotDog")]
		public short Rating { get; set; }

		[Display(Name="Comentário")]
		[Required(ErrorMessage="Informe um comentário sobre a avaliação do HotDog")]
		[StringLength(1000, ErrorMessage="O campo Comentário possui mais que 1000 caracteres")]
		[DataType(DataType.MultilineText)]
		public string ReviewText { get; set; }
	}
}