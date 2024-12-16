using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2
{
    public enum WebhookEvents
    {
        TransactionCreated,
        TransactionStateChanged,
        PayoutLinkCreated,
        PayoutLinkStateChanged
    }
}
