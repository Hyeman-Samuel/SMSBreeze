using Microsoft.AspNetCore.Mvc;
using SMSBreeze.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Controllers.API
{
	public class VerifyPayment : ControllerBase
	{
		[HttpPost]
		public SmsTransaction PaymentConfirmation(SmsTransaction transact)
		{
			return transact;
		}
	}
}
