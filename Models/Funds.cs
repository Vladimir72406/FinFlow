using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Funds
    {
		public int Funds_id { get; set; } //int primary key identity(1,1),
		public decimal SendAmount { get; set; } //decimal not null,
		public int SendCurrency { get; set; }//int not null,
		public decimal ReceiveAmount { get; set; } //decimal not null,
		public int ReceiveCurrency { get; set; } //int not null,
		public decimal Rate { get; set; } //decimal (18,6) not null,

		public Guid Remittance_Id { get; set; } //uniqueidentifier not null references Remittance(Remittance_id)

	}
}
