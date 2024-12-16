using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2
{
    public class UpdateWebhookReq
    {
        [JsonProperty("url",NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore, ItemConverterType = typeof(StringEnumConverter))]
        public List<WebhookEvents> Events { get; set; }

        public UpdateWebhookReq(string url = null, List<WebhookEvents> events = null)
        {
            Url = url;
            Events = events;
        }
    }
}
