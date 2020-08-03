using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Results
{
    public class ResultRemittance : Result
    {
        public Remittance remittance { get; set; }

        public ResultRemittance(int code, string err, Remittance _remittance) : base (code, err)
        {
            this.remittance = _remittance;            
        }

        public ResultRemittance() { }
    }
}
