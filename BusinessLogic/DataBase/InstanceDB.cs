using BusinessLogic.DataBase.MSSQLEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataBase
{    
    public static class InstanceDB
    {
        private static IRepositoryPerson repositoryPerson;
        private static IRepositoryRemittance repositoryRemittance;
        private static IRepositoryFunds repositoryFunds;
        public static IRepositoryPerson getInstancePerson()
        {
            if (repositoryPerson == null)
                repositoryPerson = new RepositoryPerson();

            return repositoryPerson;
        }

        public static IRepositoryRemittance getInstanceRemittance()
        {
            if (repositoryRemittance == null)
                repositoryRemittance = new RepositoryRemittance();

            return repositoryRemittance;
        }

        public static IRepositoryFunds getInstanceFunds()
        {
            if (repositoryFunds == null)
                repositoryFunds = new RepositoryFunds();

            return repositoryFunds;
        }
    }
}
