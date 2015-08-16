using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data
{
    public class RepositoryCountry : Repository<Country,int>, ICountryRepository
    {

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Country> Search(Country criterio)
        {
            throw new NotImplementedException();
        }

        public List<Country> Search(string criterio)
        {
            throw new NotImplementedException();
        }
    }
}
