using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICriminalService
    {
        bool ExecuteSearch(string email,string searchTerm,string name,int? ageStart,int? ageEnd,int? idSex,int? idCountry);
    }
}
