using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SMSBreeze.Models.Entities;
using SMSBreeze.Web.Models;

namespace SMSBreeze.Web.Controllers
{
    public class SmsController : Controller
    {
        public IActionResult SendSms()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendSms(MessageObjectViewModel messageObjectViewModel)
        {
            SMSServiceEBulk eBulk = new SMSServiceEBulk();
            var Response = await eBulk.SendSMSPOSTMethodAsync(messageObjectViewModel);
            SentReport sentReport = new SentReport()
            {
                
               Message = Response.Message,
               Subject = Response.Subject,
              DateSent =DateTime.Now.Date,
            };
            return RedirectToAction("SmSDetails",Response);
        }
        public IActionResult SmSDetails(CommunicationResponseViewModel Respose)
        {
            return View(Response);
        }

    }
}