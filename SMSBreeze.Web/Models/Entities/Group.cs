﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Models.Entities
{
	public class Group
	{
		public int ID { get; set; }
        [StringLength(20)]
        [Required]
        public string GroupName { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<GroupAssign> Members { get; set; }

        public Group()
        {
            this.Members = new List<GroupAssign>(); 
        }
	}
}
