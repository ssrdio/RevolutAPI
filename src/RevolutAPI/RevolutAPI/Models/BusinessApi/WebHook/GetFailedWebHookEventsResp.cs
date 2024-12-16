using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.WebHookV2.WebHookEvents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2
{
    public class GetFailedWebHookEventsResp
    {
        [JsonProperty("id")]
        public string Id {  get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("webhook_id")]
        public string WebhookId { get; set; }
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; set; }
        [JsonProperty("payload")]
        public IWebhookPayload Payload { get; set; }
        [JsonProperty("last_sent_date")]
        public DateTime LastSentDate { get; set; }

    }
    
}
