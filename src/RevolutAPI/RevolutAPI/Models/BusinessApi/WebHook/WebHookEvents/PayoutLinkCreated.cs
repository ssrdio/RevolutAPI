using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2.WebHookEvents
{
    public class PayoutLinkCreated : IWebhookPayload
    {
        public string Event { get; set; }
        public string Timestamp { get; set; }
        public PayoutLinkCreated Data { get; set; }

    }
    public class PayoutLinkCreatedData
    {
        public string Id { get; set; }
        public string State { get; set; }
        public string RequestId { get; set; }
    }
}
