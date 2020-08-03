using Models.Results;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DataBase;

namespace BusinessLogic.Logic
{
    public class ManagerTransfer
    {
        IRepositoryRemittance repositoryRemittance = InstanceDB.getInstanceRemittance();
        IRepositoryFunds repositoryFunds = InstanceDB.getInstanceFunds();
        public ResultRemittance createNewTransfer(Models.Remittance newRemitance)
        {
            ResultRemittance resultOfCreateRemittance;
            ResultFunds resultOfCreateFunds;

            resultOfCreateRemittance = repositoryRemittance.addRemittance(newRemitance);

            if (resultOfCreateRemittance.code < 0)
                return new ResultRemittance(-1, "Ошибка создания перевода", null);
            
            newRemitance.Remittance_Id = resultOfCreateRemittance.remittance.Remittance_Id;
            Models.Funds funds = newRemitance.lstFunds.ElementAt(0);
            funds.Remittance_Id = newRemitance.Remittance_Id;

            resultOfCreateFunds = repositoryFunds.addFunds(funds);

            if (resultOfCreateFunds.code < 0)
                return new ResultRemittance(-1, "Ошибка создания перевода, создание сyмм.", null);



            return new ResultRemittance(0, "", newRemitance);
        }

        public Result remittanceChangeState(TransferModifyState _transferModifyState)
        {
            var resultChangeStatus = repositoryRemittance.remittanceChangeStatus(_transferModifyState);

            return resultChangeStatus;

        }
    }
}
