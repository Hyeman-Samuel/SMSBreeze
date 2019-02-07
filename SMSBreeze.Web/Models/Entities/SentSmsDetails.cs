using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class SentSmsDetails
	{
		public int ID { get; set; }
		public string Recipient { get; set; }
		public string DeliveryReport { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public SentReport SentReport { get; set; }

	}
}
