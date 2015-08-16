using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data
{
    public class RepositoryCriminal : Repository<Criminal, Guid>, ICriminalRepository
    {

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Criminal> Search(string searchTerm)
        {
            using (CriminalContext context = new CriminalContext()) 
            {
                var query = from c in context.Criminal.Include("CrimesHistory").Include("CrimesHistory.Adress").Include("CrimesHistory.Adress.City").Include("CrimesHistory.Adress.City.State").Include("CrimesHistory.Adress.City.State.Country").Include("SexType").Include("Adress").Include("Adress.City").Include("Adress.City.State").Include("Adress.City.State.Country")
                              where c.Name.Contains(searchTerm)
                              || c.Adress.Street.Contains(searchTerm)
                              || (c.Adress.Number != null && c.Adress.Number.Value.ToString().Contains(searchTerm))
                              select c;

                  return query.ToList();
            }
        }


        public List<Criminal> Search(Criminal criterio)
        {
            using (CriminalContext context = new CriminalContext())
            {
                var query = from c in context.Criminal.Include("SexType").Include("Adress").Include("Adress.City").Include("Adress.City.State").Include("Adress.City.State.Country")
                            where c.Name.Contains(criterio.Name)
                            || c.Adress.Street.Contains(criterio.Adress.Street)
                            select c;

                return query.ToList();
            }
        }

        public List<Criminal> CustomSearch(string searchTerm, string name, int? ageStart, int? ageEnd, int? idSex, int? idCountry)
        {
            using (CriminalContext context = new CriminalContext())
            {
                var query = from c in context.Criminal.Include("CrimesHistory").Include("CrimesHistory.CrimeTypes").Include("CrimesHistory.Adress").Include("CrimesHistory.Adress.City").Include("CrimesHistory.Adress.City.State").Include("CrimesHistory.Adress.City.State.Country").Include("SexType").Include("Adress").Include("Adress.City").Include("Adress.City.State").Include("Adress.City.State.Country")
                            where  (c.Name.Contains(searchTerm) || c.Adress.Street.Contains(searchTerm))
                            && (c.Name.Contains(name))
                            && ((ageStart == null || c.Age >= ageStart) && (ageEnd == null || c.Age <= ageEnd))
                            && (idSex == null || c.IdSexType == idSex)
                            && (idCountry == null || c.Adress.City.State.IdCountry == idCountry)
                            select c;

                return query.ToList();
            }
        }
    }
}
