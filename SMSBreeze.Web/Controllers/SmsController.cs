using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMSBreeze.Models.Entities;
using SMSBreeze.Web.Data;
using SMSBreeze.Web.Models;

namespace SMSBreeze.Web.Controllers
{
    public class SmsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public SmsController(ApplicationDbContext dbContext,SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public IActionResult SendSms()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendSms(MessageObjectViewModel messageObjectViewModel)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _dbContext.Customers.First(x => x.ApplicationUserId == user.Id);
            SMSServiceEBulk eBulk = new SMSServiceEBulk();
            var Response = await eBulk.SendSMSPOSTMethodAsync(messageObjectViewModel);
            SentReport Report = new SentReport()
            {
                CustomerId =_customer.ID,
                Status = Response.Status ? "Success" : "Failed",
                UnitsUsed = Response.UnitsUsed,
                Message = Response.Message,
                Subject = Response.Subject,
                DateSent = DateTime.Now.Date,
                                  
            };
            var SmsDetails = new List<SentSmsDetails>();
            foreach (var item in Response.ReturnObjects)
            {
                SmsDetails.Add(new SentSmsDetails() { Name = item.Name, Recipient = item.Recipient, IsDeliveryReportChecked = Response.Status, Date = DateTime.Now.Date, SentReport = Report, SentReportID = Report.ID });
            }
            Report.SentSmsDetails = SmsDetails;
            if(Report.Status == "Failed")
            {
                //Throw ClientSide Exception
            }
            else { 
            _dbContext.Add(Report);
            _dbContext.SaveChanges();
            }
            return RedirectToAction();
        }
    public IActionResult SmSDetails()
    {
        return View();
    }
}
}

  