using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Webhook
{
    public class CreateWebhookResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("events")]
        [JsonConverter(typeof(StringEnumConverter))]
        public List<WebhookTypeEnum> Events { get; set; }
        [JsonProperty("signing_secret")]
        public string SigningSecret { get; set; }
    }
}
