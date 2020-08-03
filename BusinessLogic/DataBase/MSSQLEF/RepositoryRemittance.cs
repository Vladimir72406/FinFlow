using Models;
using Models.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataBase.MSSQLEF
{
    class RepositoryRemittance : IRepositoryRemittance
    {
        
        public ResultRemittance addRemittance(Models.Remittance newRemittance)
        {
            int code = 0;
            string error = "";
            ResultRemittance resultOfAddRemittance = new ResultRemittance();

            FinflowEntities fe = new FinflowEntities();

            ObjectParameter op_Remittance_Id = new ObjectParameter("Remittance_Id", newRemittance.Remittance_Id);
            ObjectParameter op_code_result = new ObjectParameter("code_result", code);
            ObjectParameter op_error = new ObjectParameter("error", error);

            fe.iud_remittance(  1,
                                op_Remittance_Id,
                                newRemittance.Code,
                                newRemittance.c_status_id,
                                newRemittance.Sender_id,
                                newRemittance.Receiver_id,
                                op_code_result,
                                op_error        );

            code = Convert.ToInt32(op_code_result.Value);
            error = Convert.ToString(op_error.Value);

            if (code < 0)
            {
                resultOfAddRemittance.code = -1;
                resultOfAddRemittance.error = "Ошибка. " + error;
                return resultOfAddRemittance;
            }
            else
            {
                resultOfAddRemittance.code = 0;
                resultOfAddRemittance.error = "";
                resultOfAddRemittance.remittance = newRemittance;
                resultOfAddRemittance.remittance.Remittance_Id = Guid.Parse(op_Remittance_Id.Value.ToString());
                return resultOfAddRemittance;
            }

        }

        public Result remittanceChangeStatus(TransferModifyState _transferModifyState)
        {
            int code = 0;
            string error = "";
            ObjectParameter op_code = new ObjectParameter("code", code);
            ObjectParameter op_error = new ObjectParameter("error", error);

            Result resultOfChangeStatus = new Result();
            FinflowEntities fe = new FinflowEntities();

            fe.remittance_change_status(_transferModifyState.Remittance_Id,
                                            _transferModifyState.c_status_id,
                                            op_code,
                                            op_error);

            code = Convert.ToInt32(op_code.Value);
            error = Convert.ToString(error);

            if (code < 0)
            {
                resultOfChangeStatus.code = -1;
                resultOfChangeStatus.error = "Ошибка. " + error;
                return resultOfChangeStatus;
            }
            else
            {
                resultOfChangeStatus.code = 0;
                resultOfChangeStatus.error = "";
                return resultOfChangeStatus;
            }
                        
        }
    }
}
