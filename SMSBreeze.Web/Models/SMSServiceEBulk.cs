using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Models
{
    public struct CommunicationResponseViewModel
    {

        public bool Status { get; set; }
        public decimal UnitsUsed { get; set; }
        public string Response { get; set; }
        public string Message { get; set; }

        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public List<CommunicationReportDetail> ReturnObjects { get; set; }
        public CommunicationMedium MessageType { get; set; }
    }



    public class SMSServiceEBulk : ISMSService
    {


        public async Task<CommunicationResponseViewModel> SendSMSPOSTMethodAsync(MessageObjectViewModel messageObjectViewModel)
        {
            var smsresponse = new CommunicationResponseViewModel();
            smsresponse.ReturnObjects = new List<CommunicationReportDetail>();

            var numbers = NumberFormatter.FormatNumbers(messageObjectViewModel);

            string wsUrl = "http://api.ebulksms.com/sendsms.json";

            EbulkSMSObject smsjson = new EbulkSMSObject();
            smsjson.SMS = new SMS();
            smsjson.SMS.auth = new Auth { apikey = "4b3e9bf70f989f6c1791e509503a0824a47ec994", username = "hyeman1738@gmail.com" };

            smsjson.SMS.message = new Message { flash = "0", messagetext = messageObjectViewModel.Message, sender = messageObjectViewModel.Subject };
            List<Gsm> gsmNumbers = new List<Gsm>();
            //generate a unique id for the messages.


            string msgid = "";

            foreach (var item in numbers)
            {
                msgid = msgid = Guid.NewGuid().ToString();
                gsmNumbers.Add(new Gsm { msidn = item.Key, msgid = msgid });

                smsresponse.ReturnObjects.Add(new CommunicationReportDetail()
                {
                    Date = DateTime.Now,
                    IsDeliveryReportChecked = false,
                    MesssageUUID = msgid,
                    Recipient = item.Key,
                    Name = item.Value,
                    DeliveryReport = "awaiting report",
                    ID = Guid.NewGuid()

                });
            }


            smsjson.SMS.recipients = new Recipients { gsm = gsmNumbers.ToArray() };

            var client = new HttpClient();
            string smsjsonString = Newtonsoft.Json.JsonConvert.SerializeObject(smsjson);

            HttpContent contentPost = new StringContent(smsjsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(new Uri(wsUrl), contentPost);

            string jsonResult = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                EbulkResponse res = JsonConvert.DeserializeObject<EbulkResponse>(jsonResult);
                switch (res.response.status)
                {
                    case "INVALID_JSON":
                        smsresponse.Message = "Invalid message formatting, please contact the software Provider";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;

                    case "MISSING_USERNAME":
                        smsresponse.Message = "The missing username, please contact the software provider";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;

                    case "MISSING_APIKEY":
                        smsresponse.Message = "The missing key, please contact the software provider";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;

                    case "AUTH_FAILURE":
                        smsresponse.Message = "Authentication failure, please contact the software provider";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;
                    case "MISSING_SENDER":
                        smsresponse.Message = "Missing Sender Name, please enter the sender's name";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;
                    case "MISSING_MESSAGE":
                        smsresponse.Message = "Missing message, please enter the sms message";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;
                    case "MISSING_RECIPIENT":
                        smsresponse.Message = "Missing recipients, please enter the sms recipients";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;
                    case "INVALID_MESSAGE":
                        smsresponse.Message = "Missing recipients, please enter the sms recipients";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;
                    case "INVALID_SENDER":
                        smsresponse.Message = "Invalid Sender, please enter a valid sender's name";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;
                    case "UNKNOWN_ERROR":
                        smsresponse.Message = "Unknown issues, please try again";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;
                    case "INSUFFICIENT_MESSAGE":
                        smsresponse.Message = "Error 101, please contact the administrator of the software";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;
                    case "SUCCESS":
                        smsresponse.Message = "Success";
                        smsresponse.Response = "Message sent";
                        smsresponse.Status = true;
                        smsresponse.UnitsUsed = 0;
                        smsresponse.Subject = smsjson.SMS.message.sender;
                        smsresponse.MessageBody = smsjson.SMS.message.messagetext;
                        smsresponse.MessageType = CommunicationMedium.SMS;


                        break;
                    default:
                        smsresponse.Message = "Error 303, try again or please contact the administrator of the software";
                        smsresponse.Response = "Message was not sent";
                        smsresponse.Status = false;
                        smsresponse.UnitsUsed = 0;
                        break;
                }
                return smsresponse;
            }
            else
            {
                return new CommunicationResponseViewModel { UnitsUsed = 0, Status = false, Message = "Error 404", Response = "The message was not sent please try again" }; ;

            }




        }
    }

    /// <summary>
    /// ViewModel
    /// </summary>
    public class ContactsViewModel
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string status { get; set; }
        public string otherInfo { get; set; }

    }


    /// <summary>
    /// ViewModel
    /// </summary>
    public class CommunicationReport
    {
        public CommunicationReport()
        {
            CommunicationReportDetails = new List<CommunicationReportDetail>();
        }
        public Guid ID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public decimal? Amount { get; set; }
        public decimal? UnitsUsed { get; set; }
        public CommunicationMedium CommunicationMedium { get; set; }
        public string SentBy { get; set; }
        public List<CommunicationReportDetail> CommunicationReportDetails { get; set; }

        public Guid TenantID { get; set; }

    }


    /// <summary>
    /// ViewModel
    /// </summary>
    public class CommunicationReportDetail
    {

        public Guid ID { get; set; }
        public Guid CommunicationReportID { get; set; }
        public CommunicationReport CommunicationReport { get; set; }
        public string Recipient { get; set; }

        public string Name { get; set; }
        public string DeliveryReport { get; set; }
        public DateTime? Date { get; set; }
        public string MesssageUUID { get; set; }
        public bool IsDeliveryReportChecked { get; set; }
    }

    /// <summary>
    /// ViewModel
    /// </summary>
    public enum CommunicationMedium
    {
        SMS,
        MMS,
        Email,
        Voice

    }

    /// <summary>
    /// ViewModel
    /// </summary>
    public class MessageObjectViewModel
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<ContactsViewModel> Contacts { get; set; }
        public string[] GroupedContacts { get; set; }
        public string ToContacts { get; set; }
        public string ToOthers { get; set; }
        public string ISOCode { get; set; }
        public string Category { get; set; }

        public string EmailAddress { get; set; }
        public string EmailDisplayName { get; set; }
    }
}