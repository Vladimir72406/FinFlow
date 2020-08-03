using Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataBase
{
    public interface IRepositoryRemittance
    {
        ResultRemittance addRemittance(Models.Remittance newRemittance);

        Result remittanceChangeStatus(Models.TransferModifyState _transferModifyState);
    }
}
