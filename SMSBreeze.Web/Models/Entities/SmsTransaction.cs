using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class SmsTransaction
	{
		public int ID { get; set; }
	
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DatePaid { get; set; }
		public string Reference { get; set; }
		public string Email { get; set; }
		public int AmountPaid { get; set; }
		public int UnitPurchased { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }
		
	}
}
	  