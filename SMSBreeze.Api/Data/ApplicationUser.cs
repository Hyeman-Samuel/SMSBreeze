using Microsoft.AspNetCore.Identity;
using SMSBreeze.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Api.Data
{
	public class ApplicationUser : IdentityUser
	{
		
		public Customer Customer { get; set; }
	}
}
