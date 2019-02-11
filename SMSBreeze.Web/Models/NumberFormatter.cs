using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Models
{
    public class NumberFormatter
    {
        public static Dictionary<string, string> FormatNumbers(MessageObjectViewModel messageObjectViewModel)
        {
            Dictionary<string, string> Keys = new Dictionary<string, string>();

            foreach (var Contacts in messageObjectViewModel.Contacts)
            {
                if (Contacts.Phone != null && Contacts.Phone.Length > 3)
                {

                    Keys.Add(Contacts.Phone, Contacts.Name);
                }

            }

            return Keys;
        }
    }
}
