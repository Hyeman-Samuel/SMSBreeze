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
		public decimal? SmsBalance { get; set; }
		public ApplicationUser  ApplicationUser { get; set; }
		public List<SmsTransaction> SmsTransactions { get; set; }
		public List<Contact> Contacts { get; set; }
		public List<SentReport> SentReports { get;set; }

        public Customer()
        {
            this.SmsTransactions = new List<SmsTransaction>();
            this.Contacts = new List<Contact>();
            this.SentReports = new List<SentReport>();
        }
	}
}
