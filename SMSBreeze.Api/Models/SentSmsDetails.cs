using System;

namespace SMSBreeze.Api.Data
{
	public class SentSmsDetails
	{
		public int ID { get; set; }
		public string Recipient { get; set; }
		public int SentReportID { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public SentReport SentReport { get; set; }
		public bool IsDeliveryReportChecked
		{
			get; set;
		}
	}
}