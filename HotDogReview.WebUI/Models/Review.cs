//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotDogReview.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int Id { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public byte Rating { get; set; }
        public string ReviewText { get; set; }
        public int EstablishmentId { get; set; }
    
        public virtual Establishment Establishment { get; set; }
    }
}
