using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.Shared
{
    public class Amount
    {
        [JsonProperty("value")]
        public double Value { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
