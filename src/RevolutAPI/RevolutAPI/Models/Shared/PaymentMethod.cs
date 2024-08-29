using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.Shared
{
    public class PaymentMethod
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("subtype")]
        public string Subtype { get; set; }
    }
}
