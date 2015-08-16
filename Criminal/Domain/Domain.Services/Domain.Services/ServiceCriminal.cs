using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCriminal : ICriminalService
    {
        ICriminalRepository repositoryCriminal;
        public ServiceCriminal(ICriminalRepository repositoryCriminal)
        {
            this.repositoryCriminal = repositoryCriminal;
        }

        public bool ExecuteSearch(string email, string searchTerm, string name, int? ageStart, int? ageEnd, int? idSex, int? idCountry)
        {
            if (ageStart > 16 && ageEnd < 100)
            {
                ProcessSearchWork(email, searchTerm, name, ageStart, ageEnd, idSex, idCountry);

                return true;
            }
            else
            {
                return false;
            }
        }

        private void ProcessSearchWork(string email, string searchTerm, string name, int? ageStart, int? ageEnd, int? idSex, int? idCountry)
        {
            ThreadStart ts = delegate
            {
                ExecuteSerchResult(email, searchTerm, name, ageStart, ageEnd, idSex, idCountry);
            };
            Thread t = new Thread(ts);
            t.Start();
        }
        private void ExecuteSerchResult(string email, string searchTerm, string name, int? ageStart, int? ageEnd, int? idSex, int? idCountry)
        {
            List<Criminal> lstCriminal = repositoryCriminal.CustomSearch(searchTerm, name, ageStart, ageEnd, idSex, idCountry);
            if (lstCriminal == null) 
            {
                lstCriminal = new List<Criminal>();
            }
            Email.SendEmail(lstCriminal, email);
        }
    }
}
