using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Remittance
    {
        public Guid Remittance_Id { get; set; }
        public string Code { get; set; }
        public int c_status_id { get; set; }
        public int Sender_id { get; set; }
        public int Receiver_id { get; set; }

        public LinkedList<Funds> lstFunds;
    }
}
