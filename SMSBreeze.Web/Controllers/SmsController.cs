using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _dbContext.Customers.First(x => x.ApplicationUserId == user.Id);
            var SmsOverview = await _dbContext.SendReports.Include(c => c.SentSmsDetails).Where(x => x.CustomerId == _customer.ID).ToListAsync();
            return View(SmsOverview);
        }
        public async Task<IActionResult> SendSms()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _dbContext.Customers.First(x => x.ApplicationUserId == user.Id);
            var MessageVM = new MessageObjectViewModel() {
                Contacts =await _dbContext.Contacts.Where(x => x.CustomerID == _customer.ID).ToListAsync(),
                Groups = await _dbContext.Groups.Where(x => x.CustomerId == _customer.ID).ToListAsync(),
                Referee =Request.Headers["Referer"].ToString()
            };
            return View(MessageVM);
        }

        [HttpPost]
        public async Task<IActionResult> SendSms(MessageObjectViewModel messageObjectViewModel,int[] groups,int[] contacts)
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _dbContext.Customers.First(x => x.ApplicationUserId == user.Id);
             if(groups != null)
             {
                foreach (var group in groups)
                {
                    var assig = await _dbContext.GroupAssigns.Where(x => x.Group.ID == group).ToListAsync();
                    foreach (var item in assig)
                    {
                        var _contact = await _dbContext.Contacts.FirstAsync(x => x.ID == item.ContactID);
                        messageObjectViewModel.GroupedContacts.Add(_contact);
                    }
                }
             }
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {                   
                        var _contact = await _dbContext.Contacts.FindAsync(contact);
                        messageObjectViewModel.Contacts.Add(_contact);                   
                }
            }
            SMSServiceEBulk eBulk = new SMSServiceEBulk();
            var Response = await eBulk.SendSMSPOSTMethodAsync(messageObjectViewModel);
                   if(Response.ValidationStatus == "Failed") {
             
                ///Throw Client Side Validation for No recepient 
                return View(messageObjectViewModel);
            }
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
                //Throw ClientSide Exception for failed message
            }
            else { 
            _dbContext.Add(Report);
            _dbContext.SaveChanges();
            }
            return View();
        }
   
}
}

  