using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RevolutAPI.Models.MerchantApi.Webhook
{
    public class UpdateWebhookReq
    {
        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
        public List<WebhookTypeEnum> Events { get; set; }
        public UpdateWebhookReq(string url = null, List<WebhookTypeEnum> events = null)
        {
            Url = url;
            Events = events;
        }
    }
}
