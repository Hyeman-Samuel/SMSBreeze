using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Models
{
  
        public class PayStackReponseViewModel
        {
            public bool status { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
            public Guid id { get; set; }
            public Guid TenantID { get; set; }

        }
        public class Data
        {


            public int amount { get; set; }
            public DateTime transaction_date { get; set; }
            public string status { get; set; }
            public string reference { get; set; }
            public string domain { get; set; }
            public Authorization authorization { get; set; }
            public Customer customer { get; set; }
            public object plan { get; set; }
        }

        public class Authorization
        {
            public string authorization_code { get; set; }
            public string card_type { get; set; }
            public string last4 { get; set; }
            public string exp_month { get; set; }
            public string exp_year { get; set; }
            public object bank { get; set; }
            public string channel { get; set; }
            public bool reusable { get; set; }
        }

        public class Customer
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
        }

    
}