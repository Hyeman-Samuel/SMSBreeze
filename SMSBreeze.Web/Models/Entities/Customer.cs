using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class Customer :IdentityUser
	{
												
		public string FullName { get; set; }
		
		public DateTime DateCreated { get; set; }
		public int SmsBalance { get; set; }
		
		public ICollection<SmsTransaction> SmsTransactions { get; set; }
		public ICollection<Contact> Contacts { get; set; }
		public ICollection<SentReport> SentReports { get;set; }
	}
}
