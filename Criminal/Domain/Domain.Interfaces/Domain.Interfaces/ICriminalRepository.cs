using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICriminalRepository : IRepository<Criminal,Guid>
    {
        List<Criminal> CustomSearch(String searchTerm, String name, int? ageStart, int? ageEnd, int? idSex, int? idCountry);
    }
}
