using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class Group
	{
		public int ID { get; set; }
		public string GroupName { get; set; }

		public ICollection<GroupAssign> Members { get; set; }
	}
}
