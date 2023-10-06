using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.Shared
{
    public class Fee
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("amount")]
        public Amount Amount { get; set; }
    }
}
