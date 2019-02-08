using Microsoft.AspNetCore.Identity;
using SMSBreeze.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class Customer
	{
		public int ID { get; set; }
		public string FullName { get; set; }
		public string ApplicationUserId { get; set; }
		public DateTime DateCreated { get; set; }
		public int SmsBalance { get; set; }
		public ApplicationUser  ApplicationUser { get; set; }
		public ICollection<SmsTransaction> SmsTransactions { get; set; }
		public ICollection<Contact> Contacts { get; set; }
		public ICollection<SentReport> SentReports { get;set; }
	}
}
