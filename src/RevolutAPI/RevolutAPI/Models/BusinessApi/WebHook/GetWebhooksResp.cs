using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2
{
    public class GetWebhooksResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("events", ItemConverterType = typeof(StringEnumConverter))]
        public List<WebhookEvents> Events { get; set; }
    }
}
