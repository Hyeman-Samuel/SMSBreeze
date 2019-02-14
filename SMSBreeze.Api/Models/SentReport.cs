using SMSBreeze.Api.Models;
using System;
using System.Collections.Generic;

namespace SMSBreeze.Api.Data
{
	public class SentReport
	{
		public int ID { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public int CustomerId { get; set; }
		public DateTime DateSent { get; set; }
		public decimal? UnitsUsed { get; set; }
		public string Status { get; set; }
		public Customer Customer { get; set; }
		public List<SentSmsDetails> SentSmsDetails { get; set; }

		public SentReport()
		{
			this.SentSmsDetails = new List<SentSmsDetails>();
		}
	}
}
