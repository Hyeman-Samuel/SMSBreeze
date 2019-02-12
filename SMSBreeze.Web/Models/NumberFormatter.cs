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

            if (messageObjectViewModel.GroupedContacts != null)
            {
                foreach (var Contacts in messageObjectViewModel.GroupedContacts)
                {
                    if (Contacts.PhoneNumber != null && Contacts.PhoneNumber.Length > 3)
                    {

                        Keys.Add(Contacts.PhoneNumber, Contacts.Name);
                    }

                }
            }

            if (messageObjectViewModel.Contacts != null) { 
            foreach (var Contacts in messageObjectViewModel.Contacts)
            {
                if (Contacts.PhoneNumber != null && Contacts.PhoneNumber.Length > 3)
                {

                    Keys.Add(Contacts.PhoneNumber, Contacts.Name);
                }

            }
            }

            
            if (messageObjectViewModel.ToContacts != null)
            {

                var Numbers = messageObjectViewModel.ToContacts.Split(",");
                foreach (var Contacts in Numbers)
                {
                    if (Contacts != null && Contacts.Length > 3)
                    {
                        Keys.Add(Contacts, "Unknown");
                    }

                }
            }

            return Keys;
        }
    }
}
