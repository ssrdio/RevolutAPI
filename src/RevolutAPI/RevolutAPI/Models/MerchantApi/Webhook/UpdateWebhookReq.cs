using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RevolutAPI.Models.MerchantApi.Webhook
{
    public class UpdateWebhookReq
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("events")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<WebhookTypeEnum> Events { get; set; }
    }
}
