using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RevolutAPI.Models.MerchantApi.Webhook
{
    public class CreateWebhookResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("events", ItemConverterType = typeof(StringEnumConverter))]
        public List<WebhookTypeEnum> Events { get; set; }
        [JsonProperty("signing_secret")]
        public string SigningSecret { get; set; }
    }
}
