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
    
    public partial class Criminal
    {
        public Criminal()
        {
            this.CrimesHistory = new HashSet<CrimesHistory>();
        }
    
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> height { get; set; }
        public Nullable<int> weight { get; set; }
        public Nullable<int> IdSexType { get; set; }
        public Nullable<int> IdAdress { get; set; }
        public string IdentificationDocument { get; set; }
    
        public virtual Adress Adress { get; set; }
        public virtual ICollection<CrimesHistory> CrimesHistory { get; set; }
        public virtual SexType SexType { get; set; }
    }
}
