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
    
    public partial class Slot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Slot()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public string id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.TimeSpan> startTime { get; set; }
        public Nullable<System.TimeSpan> endTime { get; set; }
        public string locationId { get; set; }
        public string showId { get; set; }
        public string guest { get; set; }
    
        public virtual Location Location { get; set; }
        public virtual Show Show { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
