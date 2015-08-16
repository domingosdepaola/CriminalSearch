using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data
{
    public class RepositorySexType : Repository<SexType,int>, ISexTypeRepository
    {

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SexType> Search(SexType criterio)
        {
            throw new NotImplementedException();
        }

        public List<SexType> Search(string criterio)
        {
            throw new NotImplementedException();
        }
    }
}
