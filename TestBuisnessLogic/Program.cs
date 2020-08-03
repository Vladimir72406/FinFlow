using BusinessLogic.Logic;
using Models;
using Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBuisnessLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.createTransfer();

            p.changeStatus();

        }

        public void changeStatus()
        {
            TransferModifyState _changeState = new TransferModifyState();
            _changeState.Remittance_Id = Guid.Parse("DAB06712-C962-4D74-8516-9D910EBD7688");
            _changeState.c_status_id = 2;

            ManagerTransfer transfer = new ManagerTransfer();
            var resultChangeStatus = transfer.remittanceChangeState(_changeState);
            //return resultChangeStatus;
        }

        public void createTransfer()
        {

            Funds funds = new Funds();
            funds.SendAmount = 10;
            funds.SendCurrency = 810;
            funds.ReceiveAmount = 20;
            funds.ReceiveCurrency = 840;
            funds.Rate = 2;

            Models.Remittance _newRemittance = new Remittance();
            _newRemittance.c_status_id = 1;
            _newRemittance.Code = "---";
            _newRemittance.Receiver_id = 1;
            _newRemittance.Sender_id = 1;
            _newRemittance.lstFunds = new LinkedList<Funds>();
            _newRemittance.lstFunds.AddFirst(funds);

            ResultRemittance resultOfCreateTransfer;

            if (_newRemittance == null)
            {
                resultOfCreateTransfer = new ResultRemittance();
                resultOfCreateTransfer.code = -1;
                resultOfCreateTransfer.error = "Нет параметров для создания";
                //return resultOfCreateTransfer;
            }

            ManagerTransfer transfer = new ManagerTransfer();
            resultOfCreateTransfer = transfer.createNewTransfer(_newRemittance);

            //return resultOfCreateTransfer;
        }
    }
}
