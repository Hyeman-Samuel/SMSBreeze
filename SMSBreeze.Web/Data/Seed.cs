using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Data
{
	public class Seed
	{
		public static async Task CreateRoles (
			IServiceProvider serviceProvider, IConfiguration configuration)
		{
			
			var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole >> ();
			var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			string[] roleNames = { "Admin", "User" };
			IdentityResult roleResult;

			foreach (var roleName in roleNames)
			{
				var roleExist = await RoleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
				}

			}
			var poweruserr = new ApplicationUser
			{
				UserName = configuration.GetSection("AppSettings")["UserEmail"],
				Email = configuration.GetSection("AppSettings")["UserEmail"]
			};

			string userPassword = configuration.GetSection("AppSettings")["UserPassword"];
			var user = await UserManager.FindByEmailAsync(configuration.GetSection("AppSettings")["UserEmail"]);

			if (user == null)
			{
				var createPowerUser = await UserManager.CreateAsync(poweruserr, userPassword);
				if (createPowerUser.Succeeded)
				{
					await UserManager.AddToRoleAsync(poweruserr, "Admin");
				}
			}
		}
	}
}
