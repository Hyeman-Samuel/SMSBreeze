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
		public  Contact Contact { get; set; }
		public  Group Group { get; set; }
	}
}
