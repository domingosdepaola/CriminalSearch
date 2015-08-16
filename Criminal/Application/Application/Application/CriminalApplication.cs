using Domain.Interfaces;
using Domain.Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CriminalApplication
    {
        public ICriminalRepository repositoryCriminal { get; set; }
        public ICriminalService serviceCriminal { get; set; }
        public ICountryRepository repositoryCountry { get; set; }

        public ISexTypeRepository repositorySexType { get; set; }
        public CriminalApplication() 
        {
            this.repositoryCriminal = WindsorResolver<ICriminalRepository>.Resolve();
            this.serviceCriminal = WindsorResolver<ICriminalService>.Resolve();
            this.repositoryCountry = WindsorResolver<ICountryRepository>.Resolve();
            this.repositorySexType = WindsorResolver<ISexTypeRepository>.Resolve();
        }
    }
}
