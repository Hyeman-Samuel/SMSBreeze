using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class GroupAssign
	{
		public int ID { get; set; }
		public int ContactID { get; set; }
		public virtual Contact Contact { get; set; }
		public int GroupID { get; set; }
		public virtual Group Group { get; set; }
	}
}
