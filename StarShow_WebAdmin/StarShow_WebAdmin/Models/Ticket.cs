//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StarShow_WebAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public string id { get; set; }
        public string code { get; set; }
        public string orderId { get; set; }
        public string slotId { get; set; }
        public Nullable<double> price { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Slot Slot { get; set; }
    }
}