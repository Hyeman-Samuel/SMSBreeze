using Microsoft.AspNetCore.Identity;
using SMSBreeze.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Data
{
	public class ApplicationUser : IdentityUser
	{
		
		public Customer Customer { get; set; }
	}
}
