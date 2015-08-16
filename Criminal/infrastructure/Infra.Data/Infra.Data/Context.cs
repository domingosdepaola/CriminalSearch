using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data
{
    public class CriminalContext : DbContext
    {
        public CriminalContext() : base("name=CriminalEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Criminal> Criminal { get; set; }
        public virtual DbSet<SexType> SexType { get; set; }
        public virtual DbSet<State> State { get; set; }
    }
}
