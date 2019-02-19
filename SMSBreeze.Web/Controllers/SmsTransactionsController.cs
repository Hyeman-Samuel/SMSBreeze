using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMSBreeze.Models.Entities;
using SMSBreeze.Web.Data;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

namespace SMSBreeze.Web.Controllers
{
	public class SmsTransactionsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public SmsTransactionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		// GET: SmsTransactions returns the Paystack Payment form.
		public ActionResult PaymentForm()
		{
			
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> PaymentForm([FromBody]SmsTransaction smstransactionData)
		{
			var user = await _signInManager.UserManager.GetUserAsync(User);
			var _customer = _context.Customers.First(x => x.ApplicationUserId == user.Id);


			@SmsTransaction _smsTransaction = new SmsTransaction()
			{
				Amount = smstransactionData.Amount,
				CustomerId = _customer.ID,
				Reference = smstransactionData.Reference,
				UnitPurchased = smstransactionData.Amount / 3,
				DatePaid = DateTime.Now.Date,
				Email = smstransactionData.Email,

			};
			_context.Add(_smsTransaction);
			return Json(smstransactionData);

			
		}


	}
}
