using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CriminalWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceCriminal" in both code and config file together.
    [ServiceContract]
    public interface IServiceCriminal
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        bool SearchCriminalList(string email, string searchTerm, string name, int? ageStart, int? ageEnd, int? idSex, int? idCountry);
    }
}
