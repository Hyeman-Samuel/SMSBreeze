using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class Customer
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public int DateTime { get; set; }
		public int SmsBalance { get; set; }
		
		public ICollection<SmsTransaction> SmsTransactions { get; set; }
		public ICollection<Contact> Contacts { get; set; }
		public ICollection<SentReport> SentReports { get;set; }
	}
}
