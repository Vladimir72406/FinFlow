using Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataBase
{
    public interface IRepositoryFunds
    {
        ResultFunds addFunds(Models.Funds newFunds);
    }
}
