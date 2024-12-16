using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2.WebHookEvents
{
    public class PayoutLinkStateChanged : IWebhookPayload
    {
        public string Event { get; set; }
        public string Timestamp { get; set; }
        public PayoutLinkStateChangedData Data { get; set; }
        
    }
    public class PayoutLinkStateChangedData
    {
        public string Id { get; set; }
        public string RequestId { get; set; }
        public string OldState { get; set; }
        public string NewState { get; set; }
    }
}
