using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CriminalWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceCriminal" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceCriminal.svc or ServiceCriminal.svc.cs at the Solution Explorer and start debugging.
    public class ServiceCriminal : IServiceCriminal
    {
        public void DoWork()
        {
        }
        public bool SearchCriminalList(string email,string searchTerm, string name, int? ageStart, int? ageEnd, int? idSex, int? idCountry)
        {
            CriminalApplication criminalApplication = new CriminalApplication();
            return criminalApplication.serviceCriminal.ExecuteSearch(email, searchTerm, name, ageStart, ageEnd, idSex, idCountry);
        }
    }
}
