using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Account.Objects
{
    public class EstimatedTime
    {
        [JsonProperty("unit")]
        public string Unit { get; set; }
        [JsonProperty("min")]
        public int Min { get; set; }
        [JsonProperty("max")]
        public int Max { get; set; }
    }
}
