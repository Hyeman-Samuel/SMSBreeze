using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMSBreeze.Models.Entities;
using SMSBreeze.Web.Data;
using SMSBreeze.Web.Models;

namespace SMSBreeze.Web.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext)
		{
			_userManager = userManager;
			_signInManager = signInManager;
            _dbContext = dbContext;
		}
		
		public async Task<IActionResult> Index()
		{
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _dbContext.Customers.First(x => x.ApplicationUserId == user.Id);
            //ViewBag.Person = user.Id;
            ViewBag.UnitBalance = _customer.SmsBalance;
            return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
