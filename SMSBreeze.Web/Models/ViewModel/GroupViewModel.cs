using SMSBreeze.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Models.ViewModel
{
    public class GroupViewModel
    {
        public Group Group { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
