using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SMSBreeze.Models.Entities;
using SMSBreeze.Web.Data;
using SMSBreeze.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Controllers.API
{
    public class VerifyPayment : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpClientFactory _clientfactory;

        public VerifyPayment(ApplicationDbContext dbContext, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHttpClientFactory clientFactory)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
            _clientfactory = clientFactory;
        }
        [HttpPost]
        public async Task<IActionResult> PaymentConfirmation(SmsTransaction transact)
        {
            //Get User 
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var _customer = _dbContext.Customers.First(x => x.ApplicationUserId == user.Id);
            var txnref = transact.Reference;
            //Send Get request to api  to verify
            using (var client = new HttpClient())
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", " Bearer " + "sk_test_130108a829bf9084a6e510bd3e42c916e58e73f9");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string urlparam = $"https://api.paystack.co/transaction/verify/{txnref}";
                var answer = client.GetAsync(urlparam).Result;
                if (answer.IsSuccessStatusCode)
                {
                    try
                    {
                        answer.EnsureSuccessStatusCode();
                        PayStackReponseViewModel rcode = answer.Content.ReadAsAsync<PayStackReponseViewModel>().Result;
                        if (rcode.data.status == "success")
                        {
                            //save the transaction to the database
                            var confirmedTransaction = new SmsTransaction()
                            {
                                AmountPaid = rcode.data.amount / 100,
                                CustomerId = _customer.ID,
                                Email = rcode.data.customer.email,
                                DatePaid = DateTime.Now.Date,
                                Reference = transact.Reference,
                                UnitPurchased = transact.AmountPaid/ 300,
                            };
                          
                           
                            _dbContext.Add(confirmedTransaction);
                            _customer.SmsBalance = confirmedTransaction.UnitPurchased;
                            _dbContext.Add(_customer);
                            _dbContext.SaveChanges();
                            //assign unit to the customer

                           
                            
                        }

                    }

                    catch
                    {

                    }
                }

            }
            return Ok();
        }
    }
}













