using SMSBreeze.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Models.ViewModel
{
    public class ContactViewModel
    {
        public Contact  Contact { get; set; }
        public List<Group> Groups { get; set; }
        public string Referee { get; set; }
    }
}
