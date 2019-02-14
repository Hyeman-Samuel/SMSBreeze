using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSBreeze.Api.Models;

namespace SMSBreeze.Api.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<GroupAssign> GroupAssigns { get; set; }
		public DbSet<SentReport> SendReports { get; set; }
		public DbSet<SentSmsDetails> SmsDetails { get; set; }


		
	}
}
