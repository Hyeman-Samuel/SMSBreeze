using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Models
{
    public class EbulkSMSObject
    {
        public SMS SMS { get; set; }
    }

    public class SMS
    {
        public Auth auth { get; set; }
        public Message message { get; set; }
        public Recipients recipients { get; set; }
    }
    public class Auth
    {
        public string username { get; set; }
        public string apikey { get; set; }
    }
    public class Message
    {
        public string sender { get; set; }
        public string messagetext { get; set; }
        public string flash { get; set; }
    }
    public class Recipients
    {
        public Gsm[] gsm { get; set; }
    }

    public class Gsm
    {
        public string msidn { get; set; }
        public string msgid { get; set; }
    }

    public class EbulkResponse
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public string status { get; set; }
        public string totalsent { get; set; }
        public string cost { get; set; }
    }
}
