using Models.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataBase.MSSQLEF
{
    public class RepositoryFunds : IRepositoryFunds
    {
        public ResultFunds addFunds(Models.Funds newFunds)
        {
            ResultFunds resultAddfund = new ResultFunds();
            int code = 0; ;
            string error = "";

            FinflowEntities fe = new FinflowEntities();

            ObjectParameter op_funds_id = new ObjectParameter("Funds_id", newFunds.Funds_id);
            ObjectParameter op_code = new ObjectParameter("code", code);
            ObjectParameter op_error = new ObjectParameter("error", error);

            var result = fe.iud_funds(1,
                            op_funds_id,
                            newFunds.SendAmount,
                            newFunds.SendCurrency,
                            newFunds.ReceiveAmount,
                            newFunds.ReceiveCurrency,
                            newFunds.Rate,
                            newFunds.Remittance_Id,
                            op_code,
                            op_error);
            
            code = Convert.ToInt32(op_code.Value);
            error = Convert.ToString(op_error.Value);

            if (code < 0)
            {
                resultAddfund.code = -1;
                resultAddfund.error = "Ошибка. " + error;
                return resultAddfund;
            }
            else
            {
                resultAddfund.code = 0;
                resultAddfund.error = "";
                return resultAddfund;
            }
        }
    }
}
