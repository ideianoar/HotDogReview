﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotDogReview.WebUI.Models
{
    [MetadataType(typeof(EstablishmentMetadata))]
    public partial class Establishment
    {
    }

    public class EstablishmentMetadata
    {
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}