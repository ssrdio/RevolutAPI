﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RevolutAPI.Models.MerchantApi.Webhook
{
    public class CreateWebhookReq
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("events", ItemConverterType = typeof(StringEnumConverter))]
        public List<WebhookTypeEnum> Events { get; set; }
        public CreateWebhookReq(string url, List<WebhookTypeEnum> events)
        {
            Url = url;
            Events = events;
        }
    }
}
