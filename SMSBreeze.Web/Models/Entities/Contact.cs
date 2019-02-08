using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class Contact
	{
		public int ID { get; set; }
		public int CustomerID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
	
		public	Customer Customer { get; set; }
	
		public Collection<GroupAssign> GroupAssign { get; set; }
	}
}
