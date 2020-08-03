using BusinessLogic.Logic;
using Models;
using Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinFlowWebApi.Controllers
{
    public class TransferController : ApiController
    {
        
        [HttpPost]
        public ResultRemittance Create([FromBody]Remittance _newRemittance) 
        {
            ResultRemittance resultOfCreateTransfer;

            if (_newRemittance == null)
            {
                resultOfCreateTransfer = new ResultRemittance();
                resultOfCreateTransfer.code = -1;
                resultOfCreateTransfer.error = "Нет параметров для создания";
                return resultOfCreateTransfer;
            }

            ManagerTransfer transfer = new ManagerTransfer();
            resultOfCreateTransfer = transfer.createNewTransfer(_newRemittance);
            
            return resultOfCreateTransfer;
        }
        [HttpPut]
        public Result ChangeState([FromBody]TransferModifyState _changeState) 
        {
            ManagerTransfer transfer = new ManagerTransfer();
            var resultChangeStatus = transfer.remittanceChangeState(_changeState);
            return resultChangeStatus;
        }
    }
}
