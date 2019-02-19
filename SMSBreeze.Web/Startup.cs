using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSBreeze.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace SMSBreeze.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));


			services.AddDefaultIdentity<ApplicationUser>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredUniqueChars = 0;
			});
            services.AddHttpClient();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ApplicationDbContext context)
		{
			
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			//await CreateRoles(context, serviceProvider);

		}

		//private async Task CreateRoles(ApplicationDbContext context, IServiceProvider serviceProvider)
		//{

		//	// adding custom roles

		//	var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

		//	var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

		//	string[] roleNames = { "Admin", "User" };

			

		//	foreach (var roleName in roleNames)

		//	{

		//		//creating the roles and seeding them to the database

		//		var roleExist = await RoleManager.RoleExistsAsync(roleName);

		//		if (!roleExist)

		//		{

		//			IdentityResult roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));

		//		}
		//	}


		//		var poweruser = new ApplicationUser
		//		{


		//		UserName = Configuration.GetSection("UserSettings")["UserEmail"],

		//		Email = Configuration.GetSection("UserSettings")["UserEmail"]

		//		};

		//	string UserPassword = Configuration.GetSection("UserSettings")["UserPassword"];

		//	ApplicationUser _user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);
		
		//	if (_user == null)
		//	{
		//		var createPowerUser = await UserManager.CreateAsync(poweruser, UserPassword);

		//		if (createPowerUser.Succeeded)

		//		{
		//			await UserManager.AddToRoleAsync(poweruser, "Admin");;
		//		}

		//	}

		//}
		//}
	}
}

