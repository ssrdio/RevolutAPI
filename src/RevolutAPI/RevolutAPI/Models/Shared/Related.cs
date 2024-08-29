using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.Shared
{
    public class Related
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderTypeEnum Type { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }
    }
}
