using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class Contact
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
	
		public virtual Customer Customer { get; set; }
	
		public GroupAssign GroupAssign { get; set; }
	}
}
