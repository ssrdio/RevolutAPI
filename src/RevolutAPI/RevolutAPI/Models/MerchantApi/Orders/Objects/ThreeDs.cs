using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class ThreeDs
    {
        [JsonProperty("eci")]
        public string Eci { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
