using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Webhook
{
    public class CreateWebhookReq
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("events")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<WebhookTypeEnum> Events { get; set; }
    }
}
