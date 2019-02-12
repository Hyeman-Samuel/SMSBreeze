using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class SentReport
	{
		public int ID { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public int CustomerId { get; set; }
		public DateTime DateSent { get; set; }
        public decimal? Amount { get; set; }
        public decimal? UnitsUsed { get; set; }
        public string Status { get; set; }
		public Customer Customer { get; set; }
		public ICollection<SentSmsDetails> SentSmsDetails{ get; set; }


	}
}
