using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Models
{
    public interface ISMSService
    {
        Task<CommunicationResponseViewModel> SendSMSPOSTMethodAsync(MessageObjectViewModel messageObjectViewModel);
    }
}
