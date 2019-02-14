using SMSBreeze.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Models.ViewModel
{
    public class CheckBox
    {
        public Contact Contact { get; set; }
        public bool Checked { get; set; }
    }
}
