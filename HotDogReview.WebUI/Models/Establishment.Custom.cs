using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotDogReview.WebUI.Models
{
    [MetadataType(typeof(EstablishmentMetadata))]
    public partial class Establishment
    {
        public double AverageRating
        {
            get
            {
                if (this.Reviews != null && this.Reviews.Count > 0)
                {
                    return Reviews.Average(r => r.Rating);
                }

                return 0D;
            }
        }
    }

    public class EstablishmentMetadata
    {
		[Display(Name="Nome")]
		[Required(ErrorMessage="Informe o campo Nome")]
		[StringLength(100, ErrorMessage="O campo Nome contém mais que 100 caracteres")]
		public string Name { get; set; }

		[Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
		[StringLength(1000, ErrorMessage = "O campo Descrição contém mais que 1000 caracteres")]
        public string Description { get; set; }

		[Display(Name="Endereço Completo")]
		[Required(ErrorMessage="Informe o campo Endereço Completo")]
		public string Address { get; set; }

		[Display(Name="Possui Dog Vegetariano ?")]
		public bool IsVegan { get; set; }
    }
}