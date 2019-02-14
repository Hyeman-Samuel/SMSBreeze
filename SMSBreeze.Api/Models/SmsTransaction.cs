using System;

namespace SMSBreeze.Api.Models
{
	public class SmsTransaction
	{
		public int ID { get; set; }
		public string ReferenceNumber { get; set; }
		public DateTime DatePaid { get; set; }
		public decimal AmountPaid { get; set; }
		public int UnitPurchased { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
	}
}