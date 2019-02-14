using SMSBreeze.Api.Models;
using System.Collections.ObjectModel;

namespace SMSBreeze.Api.Data
{
	public class Contact
	{
		public int ID { get; set; }
		public int CustomerID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

		public Customer Customer { get; set; }

		public Collection<GroupAssign> GroupAssign { get; set; }
	}
}