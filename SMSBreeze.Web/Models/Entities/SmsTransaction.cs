﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class SmsTransaction
	{
		public int ID { get; set; }
		public DateTime DatePaid { get; set; }
		public int UnitPurchased { get; set; }
		public string personalName { get; set; }
		public decimal AmountPaid { get; set; }
		public Customer Customer { get; set; }
		
	}
}
	  