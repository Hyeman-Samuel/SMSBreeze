using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class Contact
	{
		public int ID { get; set; }
		public int CustomerID { get; set; }
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(11)]
        [Required]
        public string PhoneNumber { get; set; }
	
		public	Customer Customer { get; set; }
	
		public Collection<GroupAssign> GroupAssign { get; set; }
	}
}
