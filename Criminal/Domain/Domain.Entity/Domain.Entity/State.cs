//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class State
    {
        public State()
        {
            this.City = new HashSet<City>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> IdCountry { get; set; }
    
        public virtual ICollection<City> City { get; set; }
        public virtual Country Country { get; set; }
    }
}
