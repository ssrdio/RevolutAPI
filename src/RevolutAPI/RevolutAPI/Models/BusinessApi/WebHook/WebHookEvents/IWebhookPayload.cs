using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2.WebHookEvents
{
    public interface IWebhookPayload
    {
        string Event {  get; set; }
        string Timestamp { get; set; }
    }
}
